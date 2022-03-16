using System.Collections.Generic;

namespace ApiMetrics
{
    /// <summary>
    /// Класс - обертка для хранения Agent
    /// </summary>
    public class AgentHolder
    {
        public List<AgentInfo> Values = new List<AgentInfo>();

        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="agent"></param>
        public void Add(AgentInfo agent)
        {
            Values.Add(agent);
        }

        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="agent"></param>
        public void Delete(AgentInfo agent)
        {
            Values.Remove(agent);
        }
    }
}
