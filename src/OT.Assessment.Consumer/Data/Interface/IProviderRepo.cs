using OT.Assessment.Consumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Assessment.Consumer.Data.Interface
{
  public interface IProviderRepo : IEditRepo<Provider>
  {
    bool CheckIfExists (string Name);

  }
}
