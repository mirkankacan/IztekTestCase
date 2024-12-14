using IztekTestCase.Dtos.TableStatusDtos;

namespace IztekTestCase.Dtos.TableDtos
{
    public class ResultTableDto
    {
        public int TableId { get; set; }

        public int TableNo { get; set; }

        public ResultTableStatusDto TableStatus { get; set; }
    }
}