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
                return await _unitOfWokDapper.CardQueries.GetCardByProjectId(getCardRequestDTO.ProjectId);
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
                    retrieveCardData.ToEntity(card);
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
