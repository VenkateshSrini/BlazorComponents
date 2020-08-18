using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorComponent.Shared;
namespace BlazorComponent.Client.InterApp
{
    public interface IQuizControl
    {

        string NextQuestionOrDone { set; get; }
        EventCallback<bool> OnCompleted { get; set; }
        QAndA QuestionSet { set; get; }
        public async Task ValidationComplete()
        {
            await OnCompleted.InvokeAsync(true);
        }

    }
}
