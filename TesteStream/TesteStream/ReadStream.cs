using System;

namespace TesteStream
{
    public class ReadStream
    {
        public static char firstChar(IStream input)
        {
            // Iniciando as variáveis auxiliares
            int size = 5, index = 0;

            // Array dos caracteres de vogais encontrados na stream
            char[] vogais = new char[size];

            // Array com a quantidade de vezes que um caractere vogal aparece
            short[] qtdVogaisRepetidos = new short[size];
            // Array que indica se a vogal aparece após uma consoante na stream
            bool[] vogalAposConsoante = new bool[size];
            // Indica se uma consoante já foi localizada na stream
            bool primeiraConsoante = false;

            // Realiza a iteração do stream
            while (input.hasNext())
            {
                // Obtém o caracter pela interface
                var c = input.getNext();

                // Verifica se o caractere é uma vogal
                bool vogal = c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';

                if (vogal)
                {
                    // Verificar se a vogal ja está no array de controle
                    var vogalNoArrayControle = indexOf(c, vogais);

                    // Se a vogal já se encontra no array de controle, adiciona +1 ao contador
                    if (vogalNoArrayControle >= 0)
                    {
                        qtdVogaisRepetidos[vogalNoArrayControle]++;
                        vogalAposConsoante[vogalNoArrayControle] = (primeiraConsoante);
                    }
                    else
                    {
                        // Senão adiciona vogal ao array de controle
                        vogais[index] = c;
                        qtdVogaisRepetidos[index]++;
                        vogalAposConsoante[index] = (primeiraConsoante);
                        index++;
                    }

                    // Redimenciona os arrays
                    if (index == vogais.Length)
                    {
                        Array.Resize(ref vogais, vogais.Length + size);
                        Array.Resize(ref qtdVogaisRepetidos, vogais.Length + size);
                        Array.Resize(ref vogalAposConsoante, vogais.Length + size);
                    }
                }

                //Verifica se já foi achada a primeira vogal para setar o campo booleano
                if (!primeiraConsoante)
                    primeiraConsoante = !vogal;
            }

            // Identificar o primeiro caractere vogal que não esteja repetido após a primeira consoante da stream
            int firstCharIndex = indexOfPrimeiroCaracterNaoRepetidoAposConsoante(qtdVogaisRepetidos, vogalAposConsoante);

            if (firstCharIndex < 0)
                // Informar o usuário que não há caractere que não se repete
                throw new Exception("Não foi encontrato caractere vogal com apenas uma ocorrência após uma consoante na stream.");

            // Retornar o caractere
            return vogais[firstCharIndex];
        }

        private static int indexOfPrimeiroCaracterNaoRepetidoAposConsoante(short[] qtdVogaisRepetidos, bool[] vogalAposConsoante)
        {
            for (int i = 0; i < qtdVogaisRepetidos.Length; i++)
            {
                if (qtdVogaisRepetidos[i] == 1 && vogalAposConsoante[i])
                    return i;
            }
            return -1;
        }

        private static int indexOf(char c, char[] vogais)
        {
            for (int i = 0; i < vogais.Length; i++)
            {
                if (c == vogais[i])
                    return i;
            }

            return -1;
        }
    }
}