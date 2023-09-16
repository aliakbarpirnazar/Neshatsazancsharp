using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.ProjectManagement;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Admin.SliderProjectViewModels;

namespace ServiceLayer.Services
{
    public class SliderProjectService : ISliderProject
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;


        public SliderProjectService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }
        public List<ListSliderProjectViewModel> GetAllSliderProjectAdmin(long id)
        {
            var sellerList = _context.SliderProjects.Include(x=>x.project).Where(x => x.IsRemoved == false && x.project.Id == id).OrderByDescending(x => x.Id).ToList();
          


            var resault = sellerList.Select(x => new ListSliderProjectViewModel
            {
                Id = x.Id,
                IsRemoved = x.IsRemoved,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle = x.PictureTitle,

            }).ToList();
           
            return resault;
        }

        public OperationResult CreatePicSlide(CreateSliderProjectViewModel command)
        {
            var operation = new OperationResult();
            try
            {

            var pictureName = _fileUploader.Upload(command.Picture, "SliderProjects");
            var project = new SliderProject()
            {
                
                Picture = pictureName,
                PictureAlt = command.PictureAlt,
                PictureTitle = command.PictureTitle,
                IsRemoved = false,
                ProjectId= command.ProjectId,             
                
            };

            _context.Add(project);
            _context.SaveChanges();
            return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با مدیر سایت تماس بگیرید");
            }
        }

        public OperationResult EditPicSlide(EditSliderProjectViewModel command)
        {
            var operation = new OperationResult();
            try
            {

            SliderProject project = Get(command.Id);

            if(command.Picture != null)
                {
                    var pictureName = _fileUploader.Upload(command.Picture, "SliderProjects");

                    project.Picture = pictureName;
                    project.Picture = pictureName;
                }
            project.PictureAlt = command.PictureAlt;
            project.PictureTitle = command.PictureTitle;
            _context.SaveChanges();
            return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با مدیر سایت تماس بگیرید");
            }
        }
        public SliderProject Get(long id)
        {
            return _context.SliderProjects.Find(id);
        }

        public EditSliderProjectViewModel GetDetails(long id)
        {
            return _context.SliderProjects.Include(x=>x.project).Select(x => new EditSliderProjectViewModel
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,              
                PictureStr = x.Picture,
                ProjectId = x.project.Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ListSliderProjectViewModel> GetAllDeleteSliderProjectAdmin(long id)
        {
            var sellerList = _context.SliderProjects.Include(x => x.project).Where(x => x.IsRemoved == true && x.project.Id == id).OrderByDescending(x => x.Id).ToList();



            var resault = sellerList.Select(x => new ListSliderProjectViewModel
            {
                Id = x.Id,
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,

            }).ToList();

            return resault;
        }

        public OperationResult SliderDelete(long id)
        {
            var operation = new OperationResult();
            SliderProject project = Get(id);
            if (project != null)
            {
                project.IsRemoved = true;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        public OperationResult SliderRecovery(long id)
        {
            var operation = new OperationResult();
            SliderProject project = Get(id);
            if (project != null)
            {
                project.IsRemoved = false;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }
    }
}
