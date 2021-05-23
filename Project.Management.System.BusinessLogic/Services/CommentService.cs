using Project.Management.System.BusinessLogic.Helpers;
using Project.Management.System.BusinessLogic.Services.Base;
using Project.Management.System.Data.Base;
using Project.Management.System.Model.DTO;
using Project.Management.System.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.BusinessLogic.Services
{
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IUnitOfWorkDapper unitOfWorkDapper, ILogService logger)
            : base(unitOfWork, unitOfWorkDapper, logger)
        { }

        public async Task<IEnumerable<GetCommentByCardIdResponseDTO>> GetCommentByCardId(GetCommentByCardIdRequestDTO getCommentByCardIdRequestDTO)
        {
            try
            {
                return await _unitOfWokDapper.CommentQueries.GetCommentByCardId(getCommentByCardIdRequestDTO);
            }
            catch (Exception ex)
            {
                _logger.LogExceptionError(ex.ToString());
                throw ex;
            }
        }

        public async Task SaveComment(SaveCommentRequestDTO saveCommentRequestDTO)
        {
            Comment comment = new Comment();
            try
            {
                if (saveCommentRequestDTO != null)
                {
                    saveCommentRequestDTO.ToEntity(comment);
                    await _unitOfWork.CommentRepository.InsertCommentAsync(comment);
                }
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogExceptionError(ex.ToString());
                throw ex;
            }
        }

    }
}
