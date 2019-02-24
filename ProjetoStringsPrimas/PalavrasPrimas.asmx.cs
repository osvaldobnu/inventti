using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProjetoStringsPrimas
{
    /// <summary>
    /// Descrição resumida de PalavrasPrimas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class PalavrasPrimas : System.Web.Services.WebService
    {

        [WebMethod]
        public string RecebePalavras(string palavra1, string palavra2)
        {
            bool tamanhoIgual = false;
            bool posicoesLetras = false;

            /*
             * Observação, no teste diz para verificar posições pares e ímpares, no código talvez vai parecer confuso.
             * Por que a posição 0 do das letras na palavra eu considerei 1, pensando no usuário final.
             * Exemplo: Palavra Olá, no código a posição da letra "O" é Zero, porém para o usuário final a letra "O"
             * é a número 1, ou seja no código vai parecer que a minha validação de números pares ou impar esta inversa,
             * Mas não! Foi pensando no usuário mesmo.
            */

            // Verifica tamanho
            if (VerificaTamanho(palavra1, palavra2))
                tamanhoIgual = true;

            // Verifica letras na posição impar
            if (VerificaPosicoesImpares(palavra1, palavra2) && VerificaPosicoesPares(palavra1, palavra2))
                posicoesLetras = true;

            if (tamanhoIgual && posicoesLetras)
                return "São Strings primas";
            else
                return "Não são Strings primas";
        }

        private bool VerificaTamanho(string palavra1, string palavra2)
        {
            return palavra1.Length == palavra2.Length;
        }

        private bool VerificaPosicoesPares(string palavra1, string palavra2)
        {
            ArrayList letrasPalavra1 = new ArrayList();
            ArrayList letrasPalavra2 = new ArrayList();
            ArrayList letrasRepetidas = new ArrayList();
            bool achou = false;

            bool retorno = false;

            for (int i = 0; i < palavra1.Length; i++)
            {
                if (i % 2 != 0)
                {
                    letrasPalavra1.Add(palavra1.Substring(i, 1));
                    letrasPalavra2.Add(palavra2.Substring(i, 1));
                }
            }

            for (int i = 0; i < letrasPalavra1.Count; i++)
            {
                for (int j = 0; j < letrasPalavra2.Count; j++)
                {
                    if (letrasPalavra1[i].ToString().Equals(letrasPalavra2[j]) && (!achou))
                    {
                        letrasRepetidas.Add(letrasPalavra1[i]);
                        achou = true;
                    }
                }
                achou = false;
            }

            if (letrasRepetidas.Count == letrasPalavra1.Count)
                retorno = true;

            return retorno;
        }

        private bool VerificaPosicoesImpares(string palavra1, string palavra2)
        {
            ArrayList letrasPalavra1 = new ArrayList();
            ArrayList letrasPalavra2 = new ArrayList();
            ArrayList letrasRepetidas = new ArrayList();
            bool achou = false;

            bool retorno = false;

            for (int i = 0; i < palavra1.Length; i++)
            {
                if (i % 2 == 0)
                {
                    letrasPalavra1.Add(palavra1.Substring(i, 1));
                    letrasPalavra2.Add(palavra2.Substring(i, 1));
                }
            }

            for (int i = 0; i < letrasPalavra1.Count; i++)
            {
                for (int j = 0; j < letrasPalavra2.Count; j++)
                {
                    if (letrasPalavra1[i].ToString().Equals(letrasPalavra2[j]) && (!achou))
                    {
                        letrasRepetidas.Add(letrasPalavra1[i]);
                        achou = true;
                    }
                }
                achou = false;
            }

            if (letrasRepetidas.Count == letrasPalavra1.Count)
                retorno = true;

            return retorno;
        }
    }
}
