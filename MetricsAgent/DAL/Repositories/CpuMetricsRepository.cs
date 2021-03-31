﻿using MetricsAgent.Models;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Data;

namespace MetricsAgent.DAL
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        // наше соединение с базой данных
        private IDbConnection connection;

        // инжектируем соединение с базой данных в наш репозиторий через конструктор
        public CpuMetricsRepository(IDbConnection connection)
        {
            this.connection = connection;
            // добавляем парсилку типа TimeSpan в качестве подсказки для SQLite
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(CpuMetric item)
        {
            //  запрос на вставку данных с плейсхолдерами для параметров
            connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)", 
                // анонимный объект с параметрами запроса
                new { 
                    // value подставится на место "@value" в строке запроса
                    // значение запишется из поля Value объекта item
                    value = item.Value,
                    
                    // записываем в поле time количество секунд
                    time = item.Time.TotalSeconds 
                });
        }

        public void Delete(int id)
        {
            connection.Execute("DELETE FROM cpumetrics WHERE id=@id",
                new
                {
                    id = id
                });
        }

        public void Update(CpuMetric item)
        {
            connection.Execute("UPDATE cpumetrics SET value = @value, time = @time WHERE id=@id",
                new
                {
                    value = item.Value,
                    time = item.Time.TotalSeconds, 
                    id = item.Id
                });
        }

        public IList<CpuMetric> GetAll()
        {
            // читаем при помощи Query и в шаблон подставляем тип данных
            // объект которого Dapper сам и заполнит его поля
            // в соответсвии с названиями колонок
            return connection.Query<CpuMetric>("SELECT Id, Time, Value FROM cpumetrics").ToList();
        }

        public CpuMetric GetById(int id)
        {
            return connection.QuerySingle<CpuMetric>("SELECT Id, Time, Value FROM cpumetrics WHERE id=@id", new { id = id });
        }
    }
}