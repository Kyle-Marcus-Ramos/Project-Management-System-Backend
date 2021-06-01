using Project.Management.System.Model.DTO;
using Project.Management.System.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Management.System.BusinessLogic.Helpers
{
    public static class DTOMapper
    {
        #region entityToDto
       

        #endregion


        #region EntityToDto
        public static Account ToEntity(this SaveAccountRequestDTO saveAccountRequestDTO, Account account)
        {
            account.CreatedDate = DateTime.Now;
            account.ModifiedDate = DateTime.Now;
            account.IsActive = true;
            account.IsAdmin = saveAccountRequestDTO.IsAdmin;
            account.Name = saveAccountRequestDTO.Name;
            account.Email = saveAccountRequestDTO.Email;
            account.Password = saveAccountRequestDTO.Password;
            account.Id = 0;
            return account;
        }
        public static Account ToEntity(this GetAccountByAccountIdResponseDTO saveAccountRequestDTO, Account accounts)
        {
            if (saveAccountRequestDTO.IsAdmin == null || saveAccountRequestDTO.IsAdmin == false)
                saveAccountRequestDTO.IsAdmin = false;

            Account account = new Account();
            account.CreatedDate = DateTime.Now;
            account.ModifiedDate = DateTime.Now;
            account.IsActive = true;
            account.IsAdmin = saveAccountRequestDTO.IsAdmin ?? false;
            account.Name = saveAccountRequestDTO.Name;
            account.Email = saveAccountRequestDTO.Email;
            account.Password = "Default123";
            account.Id = saveAccountRequestDTO.AccountId;
            return account;
        }

        
        public static Projects ToEntity(this SaveProjectRequestDTO saveProjectRequestDTO, Projects project)
        {
            project.CreatedDate = DateTime.Now;
            project.ModifiedDate = DateTime.Now;
            project.IsActive = true;
            project.Name = saveProjectRequestDTO.Name;
            project.UserId = saveProjectRequestDTO.AccountId;
            project.Id = 0;
            return project;
        }

        public static Card ToEntity(this SaveCardRequestDTO saveCardRequestDTO, Card card)
        {
            card.CreatedDate = DateTime.Now;
            card.ModifiedDate = DateTime.Now;
            card.IsActive = true;
            card.Title = saveCardRequestDTO.Title;
            card.Status = saveCardRequestDTO.Status;
            card.Description = saveCardRequestDTO.Description;
            card.Assignee = saveCardRequestDTO.Assignee;
            card.Reporter = saveCardRequestDTO.Reporter;
            card.Priority = saveCardRequestDTO.Priority;
            card.Estimate = Convert.ToDateTime(saveCardRequestDTO.Estimate);
            card.ProjectId = saveCardRequestDTO.ProjectId;
            card.Id = 0;
            return card;
        }

        public static Card ToEntity(this UpdateCardRequestDTO updateCardRequestDTO, Card card, int position)
        {
            switch (position)
            {
                case 0:
                    {
                        card.Status = "TO DO";
                        break;
                    }
                case 1:
                    {
                        card.Status = "IN PROGRESS";
                        break;
                    }
                case 2:
                    {
                        card.Status = "FOR TESTING";
                        break;
                    }
                case 3:
                    {
                        card.Status = "COMPLETED";
                        break;
                    }
            }

            card.CreatedDate = DateTime.Now;
            card.ModifiedDate = DateTime.Now;
            card.IsActive = true;
            card.Title = updateCardRequestDTO.Title;
            card.Description = updateCardRequestDTO.Description;
            card.Assignee = updateCardRequestDTO.Assignee;
            card.Reporter = updateCardRequestDTO.Reporter;
            card.Priority = updateCardRequestDTO.Priority;
            card.Estimate = updateCardRequestDTO.Estimate;
            card.ProjectId = Convert.ToInt32(updateCardRequestDTO.ProjectId);
            card.Id = updateCardRequestDTO.CardId;
            return card;
        }

        public static Comment ToEntity(this SaveCommentRequestDTO saveCommentRequestDTO, Comment comment)
        {
            comment.CreatedDate = DateTime.Now;
            comment.ModifiedDate = DateTime.Now;
            comment.IsActive = true;
            comment.UserId = saveCommentRequestDTO.UserId;
            comment.CardId = saveCommentRequestDTO.CardId;
            comment.Comments = saveCommentRequestDTO.Comment;
            comment.Id = 0;
            return comment;
        }

        #endregion
    }
}
