using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer
{
    internal class Inscription
{
    private static int IdCursoProgramacao = 001; // Supondo que o C_Id para o curso "Programmation" seja 001

    internal static int UpdateInscription()
    {
        DataTable dt = Data.Inscription.GetInscription().GetChanges(DataRowState.Added | DataRowState.Modified);

        if (dt != null)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    // Verifica se o estudante já está inscrito no curso "Programmation"
                    DataRow[] rows = dt.Select("E_Id = " + row["E_Id"].ToString() + " AND C_Id = " + IdCursoProgramacao);

                    if (rows.Length == 0)
                    {
                        // Se o estudante não estiver inscrito no curso "Programmation", inscreve-o
                        DataRow newRow = dt.NewRow();
                        newRow["E_Id"] = row["E_Id"];
                        newRow["C_Id"] = IdCursoProgramacao;
                        dt.Rows.Add(newRow);
                    }
                }
            }

            return Data.Inscription.UpdateInscription(); // Atualiza a tabela de inscrição com as novas alterações
        }
        else
        {
            return -1; // Retorna -1 se não houver alterações
        }
    }
}
}


