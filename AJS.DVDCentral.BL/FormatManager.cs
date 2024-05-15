using AJS.DVDCentral.BL;
using AJS.DVDCentral.BL.Models;
using Microsoft.Extensions.Logging;

namespace AJS.DVDCentral.BL
{
    public class FormatManager : GenericManager<tblFormat>
    {
        protected DbContextOptions<DVDCentralEntities> options;

        protected readonly ILogger logger;

        public FormatManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }

        //public FormatManager(DbContextOptions<DVDCentralEntities> options, ILogger logger)
        //{
        //    this.options = options;
        //    this.logger = logger;
        //}

        public int Insert(Format format, bool rollback = false)
        {
            try
            {
                tblFormat row = new tblFormat { Description = format.Description };
                format.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //public List<Format> Load()
        //{

        //    try
        //    {
        //        List<Format> rows = new List<Format>();
        //        base.Load()
        //            .ForEach(d => rows.Add(
        //                new Format
        //                {
        //                    Id = d.Id,
        //                    Description = d.Description,
        //                }));

        //        return rows;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        public Format LoadById(Guid id)
        {
            try
            {
                tblFormat row = base.LoadById(id);

                if (row != null)
                {
                    Format format = new Format
                    {
                        Id = row.Id,
                        Description = row.Description,
                    };

                    return format;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Format format, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblFormat
                {
                    Id = format.Id,
                    Description = format.Description
                }, rollback);
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return base.Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}