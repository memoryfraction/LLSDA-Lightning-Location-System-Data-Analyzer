using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Interface.Interfaces
{
    public interface IStrikeIOService
    {
        /// <summary>
        /// Get GetStrikesChina format from src txt files
        /// </summary>
        /// <param name="fullTxtSrcFiles"> full path and file names</param>
        /// <returns></returns>
        IEnumerable<BaseStrikeChina> GetStrikesChina(IEnumerable<string> fullTxtSrcFiles);

        /// strikes persistence
        System.Threading.Tasks.Task SaveStrikesChinaAsync(IEnumerable<BaseStrikeChina> strikesChina, string fullPathFile);
    }
}
