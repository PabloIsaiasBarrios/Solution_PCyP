using PCyP.Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public class QuizBusiness
    {
        private QuizRepository db;


        #region Singleton

        private static QuizBusiness _instance;

        private QuizBusiness()
        {
            this.db = new QuizRepository();
        }

        public static QuizBusiness Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QuizBusiness();
                return _instance;
            }
        }


        #endregion

        public void Add(Quiz model)
        {
            model.Id = Guid.NewGuid().ToString();
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = 0;
            model.ChangedOn = DateTime.Now;
            model.ChangedBy = 0;
            db.Add(model);
        }

        public List<Quiz> GetQuizList()
        {
            return this.db.All();
        }

        public Quiz GetQuizDetails(string id)
        {
            var model = db.Find(new Quiz { Id = id });
            return model;
        }

        public void EditQuiz(Quiz model)
        {
            model.ChangedOn = DateTime.Now;
            model.ChangedBy = 0;
            db.Edit(model);
        }

        public void DeleteQuiz(Quiz model)
        {
            db.Delete(model);
        }
    }
}
