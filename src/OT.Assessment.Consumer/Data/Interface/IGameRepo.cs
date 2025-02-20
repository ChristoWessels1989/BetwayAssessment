using OT.Assessment.Consumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Assessment.Consumer.Data.Interface
{
  public interface IGameRepo : IEditRepo<Game>
  {
    bool CheckIfExists (string Name,string ProviderName);

  }
}
