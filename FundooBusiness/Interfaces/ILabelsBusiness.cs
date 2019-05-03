using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooBusiness.Interfaces
{
   public interface ILabelsBusiness
    {
        string AddLabels(LabelModel label);

        List<LabelModel> GetLabels(Guid UserId);

        string UpdateLabels(int id, string newlabel);
        string DeleteLabel(int id);
    }
}
