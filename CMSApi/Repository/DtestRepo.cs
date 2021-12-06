using CMSApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class DtestRepo:IDtest
    {
        DBClinicContext db;
        //constructor dependancy injection;
        public DtestRepo(DBClinicContext _db)
        {
            db = _db;
        }
        #region Add Tests
        public async Task<int> AddTest(Dtests test)
        {

            if (db != null)
            {
                await db.Dtests.AddAsync(test);
                await db.SaveChangesAsync(); //commit the transaction
                return test.TestId;
            }
            return 0;

        }
        #endregion

        #region
        public async Task<List<Dtests>> GetTests()
        {

            if (db != null)
            {

                return await db.Dtests.ToListAsync();
            }
            return null;
        }
        #endregion
        public async Task<List<Ntests>> GetTestName()
        {

            if (db != null)
            {
                return await db.Ntests.ToListAsync();
            }
            return null;
        }
    }
}
