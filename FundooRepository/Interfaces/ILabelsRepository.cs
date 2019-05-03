using Common.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
   public interface ILabelsRepository
    {
        string AddLabels([FromBody] LabelModel label);

        List<LabelModel> GetLabels(Guid UserId);
        string UpdateLabels(int id, string newlabel);
        string DeleteLabel(int id);
    }
}
