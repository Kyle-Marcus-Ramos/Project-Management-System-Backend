using Project.Management.System.BusinessLogic.Services.Base;
using Project.Management.System.Data.Base;
using Project.Management.System.Model.DTO;
using Project.Management.System.Model.Entities;
using System;
using System.Threading.Tasks;
using Project.Management.System.BusinessLogic.Helpers;
using System.Collections.Generic;

namespace Project.Management.System.BusinessLogic.Services
{
    public class CardService : BaseService, ICardService
    {
        public CardService(IUnitOfWork unitOfWork, IUnitOfWorkDapper unitOfWorkDapper, ILogService logger)
            : base(unitOfWork, unitOfWorkDapper, logger)
        { }

        public async Task<IEnumerable<GetCalendarByProjectIdResponseDTO>> GetCalendarByProjectId(GetCalendarByProjectIDRequestDTO calendarByProjectIDRequestDTO)
        {
            try
            {
                return await _unitOfWokDapper.CardQueries.GetCalendarByProjectId(calendarByProjectIDRequestDTO);
            }
            catch (Exception ex)
            {
                _logger.LogExceptionError(ex.ToString());
                throw ex;
            }
        }

        public async Task<IEnumerable<GetCardResponseDTO>> GetCardByProjectId(GetCardRequestDTO getCardRequestDTO)
        {
            try
            {
                List<GetCardResponseDTO> response = new List<GetCardResponseDTO>();
                GetCardResponseDTO cardResponses = null;
                //var result = await _unitOfWokDapper.CardQueries.GetCardByProjectId(getCardRequestDTO.ProjectId);

                var toDoResult = await _unitOfWokDapper.CardQueries.GetCardByStatus("TO DO");
                var inProgressResult = await _unitOfWokDapper.CardQueries.GetCardByStatus("IN PROGRESS");
                var forTestingResult = await _unitOfWokDapper.CardQueries.GetCardByStatus("FOR TESTING");
                var completedResult = await _unitOfWokDapper.CardQueries.GetCardByStatus("COMPLETED");

                var cardToDoResponses = new GetCardResponseDTO()
                {
                    Position = 0,
                    Name = "TO DO",
                    Cards = toDoResult
                };

                var cardInProgressResponses = new GetCardResponseDTO()
                {
                    Position = 1,
                    Name = "IN PROGRESS",
                    Cards = inProgressResult
                };

                var cardForTestingResponses = new GetCardResponseDTO()
                {
                    Position = 2,
                    Name = "FOR TESTING",
                    Cards = forTestingResult
                };

                var cardCompletedResponses = new GetCardResponseDTO()
                {
                    Position = 3,
                    Name = "COMPLETED",
                    Cards = completedResult
                };
                response.Add(cardToDoResponses);
                response.Add(cardInProgressResponses);
                response.Add(cardForTestingResponses);
                response.Add(cardCompletedResponses);

                //foreach (var res in result)
                //{
                //    cardResponses = new GetCardResponseDTO()
                //    {
                //        Name = "todo",

                //    };
                //    response.Add(cardResponses);
                //}
                return response;
                //return null;
            }
            catch (Exception ex)
            {
                _logger.LogExceptionError(ex.ToString());
                throw ex;
            }
        }

        public async Task SaveCard(SaveCardRequestDTO saveCardRequestDTO)
        {
            Card card = new Card();
            try
            {
                if (saveCardRequestDTO != null)
                {
                    saveCardRequestDTO.ToEntity(card);
                    await _unitOfWork.CardRepository.InsertCardAsync(card);
                    await _unitOfWork.Complete();
                }

            }catch(Exception ex)
            {
                _logger.LogExceptionError(ex.ToString());
                throw ex;
            }
        }

        public async Task UpdateCard(UpdateCardRequestDTO updateCardRequestDTO)
        {
            Card card = new Card();
            try
            {
                if (updateCardRequestDTO != null)
                {
                    var retrieveCardData = await _unitOfWokDapper.CardQueries.GetCardByCardData(updateCardRequestDTO);
                    retrieveCardData.ToEntity(card, updateCardRequestDTO.Position);
                     await _unitOfWork.CardRepository.UpdateCardAsync(card);
                }
            }
            catch (Exception ex)
            {
                _logger.LogExceptionError(ex.ToString());
                throw ex;
            }
        }
    }
}
