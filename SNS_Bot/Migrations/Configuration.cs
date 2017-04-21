namespace tweetBot.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<tweetBot.Context.SerifDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.SerifDataContext context)
        {

            //var serifCSV = CSVRead.getSerifCSV(
            //    @"none");


            //foreach (var serifData in serifCSV)
            //{
            //    context.Serifs.AddOrUpdate(p => p.Id,
            //    new Models.SerifData
            //    {
            //        /*Id = lastId,*/
            //        Name = serifData.Name,
            //        Text = serifData.Text,
            //        LastUsedTime = null,
            //        Type = serifData.Type
            //    });
            //}

            context.Serifs.Add(new Models.SerifData { Name = "����", Text = "���₷�݂Ȃ����A���Z�����I", Type = Models.SerifType.Oyasumi });

            context.SaveChanges();
            /*try { }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var er in e.EntityValidationErrors)
                {
                    foreach (var item in er.ValidationErrors)
                    {
                        string logmes = $"{item.PropertyName}:{item.ErrorMessage}";
                        System.Diagnostics.Trace.WriteLine(logmes);
                        System.Console.WriteLine(logmes);
                    }
                }
                throw e;
            }*/


        }
    }

}
