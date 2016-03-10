using System;
using System.Collections.Generic;
using System.Linq;

namespace Acquaint.Data
{

    public static class AcquaintanceDataSourceHelper
    {
        static int MatchScore(Acquaintance c, string query)
        {
            return new[]
            {
                $"{c.FirstName} {c.LastName}",
                c.Email,
                c.Company,
            }.Sum(label => MatchScore(label, query));
        }

        static int MatchScore(string data, string query)
        {
            int score = query.Length;

            if (string.IsNullOrEmpty(data))
                return 0;

            data = data.ToLower();
            if (!data.Contains(query))
                return 0;

            if (data == query)
                score += 2;
            else if (data.StartsWith(query))
                score++;

            return score;
        }

        public static IEnumerable<Acquaintance> BasicQueryFilter(IEnumerable<Acquaintance> source, string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return source.OrderBy(e => e.LastName ?? "");
            }

            query = query.ToLower();
            return source
                .Select(c => Tuple.Create(MatchScore(c, query), c))
                .Where(c => c.Item1 != 0)
                .OrderByDescending(e => e.Item1)
                .Select(c => c.Item2);
        }
    }
}

