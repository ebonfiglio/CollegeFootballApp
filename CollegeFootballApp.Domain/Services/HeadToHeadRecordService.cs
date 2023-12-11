using CollegeFootballApp.Domain.Entities;
using CollegeFootballApp.Domain.Interfaces;
using CollegeFootballApp.Domain.Models.Dtos;
using CollegeFootballApp.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Services
{
    public class HeadToHeadRecordService : IHeadToHeadRecordService
    {
        public Dictionary<string, Dictionary<string, HeadToHeadRecordDto>> CalculateMultiCompetitorHeadToHeadRecordAsync<T>(
            List<Game> games, List<T> competitors) where T : IHeadToHeadCompetitor
        {
            Dictionary<string, Dictionary<string, HeadToHeadRecordDto>> recordMatrix = new Dictionary<string, Dictionary<string, HeadToHeadRecordDto>>();

            foreach (T competitor1 in competitors)
            {
                foreach (T competitor2 in competitors)
                {
                    if (competitor1.Identifier != competitor2.Identifier)
                    {
                        HeadToHeadRecordDto headToHeadRecord = CalculateHeadToHeadRecord(games, competitor1, competitor2);
                        if (!recordMatrix.ContainsKey(competitor1.Identifier))
                        {
                            recordMatrix[competitor1.Identifier] = new Dictionary<string, HeadToHeadRecordDto>();
                        }
                        recordMatrix[competitor1.Identifier].Add(competitor2.Identifier, headToHeadRecord);
                    }
                }
            }

            return recordMatrix;
        }

        private HeadToHeadRecordDto CalculateHeadToHeadRecord(List<Game> games, IHeadToHeadCompetitor competitor1, IHeadToHeadCompetitor competitor2)
        {
            int wins = 0;
            int losses = 0;
            int draws = 0;

            foreach (Game game in games)
            {
                string winnerIdentifier = DetermineWinnerIdentifier(game);
                string loserIdentifier = DetermineLoserIdentifier(game);

                if (winnerIdentifier == null || loserIdentifier == null)
                {
                    continue; // Skip if winner or loser can't be determined
                }

                // Increment win/loss count based on whether competitor identifiers match the winner/loser
                if (winnerIdentifier == competitor1.Identifier && loserIdentifier == competitor2.Identifier)
                {
                    wins++;
                }
                else if (loserIdentifier == competitor1.Identifier && winnerIdentifier == competitor2.Identifier)
                {
                    losses++;
                }
                else if (winnerIdentifier == null && loserIdentifier == null)
                {
                    if (InvolvesCompetitors(game, competitor1.Identifier, competitor2.Identifier))
                    {
                        draws++;
                    }
                }
            }

            return new HeadToHeadRecordDto
            {
                Competitor1 = competitor1.Identifier,
                Competitor2 = competitor2.Identifier,
                Wins = wins,
                Losses = losses,
                Draws = draws,
            };
        }

        private bool IsConferenceComparison(Game game)
        {
            return !string.IsNullOrEmpty(game.HomeConferenceName) && !string.IsNullOrEmpty(game.AwayConferenceName);
        }

        public string DetermineWinnerIdentifier(Game game)
        {
            if (!game.Completed.HasValue || !game.Completed.Value || !game.HomePoints.HasValue || !game.AwayPoints.HasValue)
            {
                return null;
            }

            if (IsConferenceComparison(game))
            {
                return game.HomePoints > game.AwayPoints ? game.HomeConferenceName : game.AwayConferenceName;
            }
            else
            {
                return game.HomePoints > game.AwayPoints ? game.HomeId.ToString() : game.AwayTeamId.ToString();
            }
        }

        public string DetermineLoserIdentifier(Game game)
        {
            if (!game.Completed.HasValue || !game.Completed.Value || !game.HomePoints.HasValue || !game.AwayPoints.HasValue)
            {
                return null;
            }

            if (IsConferenceComparison(game))
            {
                return game.HomePoints < game.AwayPoints ? game.HomeConferenceName : game.AwayConferenceName;
            }
            else
            {
                return game.HomePoints < game.AwayPoints ? game.HomeId.ToString() : game.AwayTeamId.ToString();
            }
        }

       public bool InvolvesCompetitors(Game game, string identifier1, string identifier2)
        {
            // Check if the identifiers are integers (Team IDs)
            if (int.TryParse(identifier1, out int id1) && int.TryParse(identifier2, out int id2))
            {
                return (game.HomeId == id1 || game.AwayTeamId == id1) && (game.HomeId == id2 || game.AwayTeamId == id2);
            }
            // If not integers, assume they are conference names
            else
            {
                return (game.HomeConferenceName == identifier1 || game.AwayConferenceName == identifier1) &&
                       (game.HomeConferenceName == identifier2 || game.AwayConferenceName == identifier2);
            }
        }
    }
}
