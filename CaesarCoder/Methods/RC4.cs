using System.Linq;

namespace CaesarCoder.Methods
{
    

    // Пример, как можно использовать этот класс:
    
    //    byte[] key = ASCIIEncoding.ASCII.GetBytes("Key");

    //    RC4 encoder = new RC4(key);
    //    string testString = "Plaintext";
    //    byte[] testBytes = ASCIIEncoding.ASCII.GetBytes(testString);
    //    byte[] result = encoder.Encode(testBytes, testBytes.Length);

    //    RC4 decoder = new RC4(key);
    //    byte[] decryptedBytes = decoder.Decode(result, result.Length);
    //    string decryptedString = ASCIIEncoding.ASCII.GetString(decryptedBytes);

    

    public class RC4
    {
        byte[] S = new byte[256];

        int x = 0;
        int y = 0;

        public RC4(byte[] key)
        {
            init(key);
        }

        // Key-Scheduling Algorithm 
        // Алгоритм ключевого расписания 
        private void init(byte[] key)
        {
            int keyLength = key.Length;

            for (int i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % keyLength]) % 256;
                S.Swap(i, j);
            }
        }

        public byte[] Encode(byte[] dataB)
        {
            int size = dataB.Length;
            byte[] data = dataB.Take(size).ToArray();

            byte[] cipher = new byte[data.Length];

            for (int m = 0; m < data.Length; m++)
            {
                cipher[m] = (byte)(data[m] ^ keyItem());
            }

            return cipher;
        }
        public byte[] Decode(byte[] dataB)
        {
            return Encode(dataB);
        }

        // Pseudo-Random Generation Algorithm 
        // Генератор псевдослучайной последовательности 
        private byte keyItem()
        {
            x = (x + 1) % 256;
            y = (y + S[x]) % 256;

            S.Swap(x, y);

            return S[(S[x] + S[y]) % 256];
        }
    }

    static class SwapExt
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}



/*namespace CaesarCoder.Methods
{


    //Пример, как можно использовать этот класс:
    
    //    byte[] key = ASCIIEncoding.ASCII.GetBytes("Key");

    //    RC4 encoder = new RC4(key);
    //    string testString = "Plaintext";
    //    byte[] testBytes = ASCIIEncoding.ASCII.GetBytes(testString);
    //    byte[] result = encoder.Encode(testBytes, testBytes.Length);

    //    RC4 decoder = new RC4(key);
    //    byte[] decryptedBytes = decoder.Decode(result, result.Length);
    //    string decryptedString = ASCIIEncoding.ASCII.GetString(decryptedBytes);

   

public class RC4
{
    byte[] S = new byte[256];

    int x = 0;
    int y = 0;

    public RC4(byte[] key)
    {
        init(key);
    }

    // Key-Scheduling Algorithm 
    // Алгоритм ключевого расписания 
    private void init(byte[] key)
    {
        int keyLength = key.Length;

        for (int i = 0; i < 256; i++)
        {
            S[i] = (byte)i;
        }

        int j = 0;
        for (int i = 0; i < 256; i++)
        {
            j = (j + S[i] + key[i % keyLength]) % 256;
            S.Swap(i, j);
        }
    }

    public byte[] Encode(byte[] dataB)
    {
        int size = dataB.Length;
        byte[] data = dataB.Take(size).ToArray();

        byte[] cipher = new byte[data.Length];

        for (int m = 0; m < data.Length; m++)
        {
            cipher[m] = (byte)(data[m] ^ keyItem());
        }

        return cipher;
    }
    public byte[] Decode(byte[] dataB)
    {
        return Encode(dataB);
    }

    // Pseudo-Random Generation Algorithm 
    // Генератор псевдослучайной последовательности 
    private byte keyItem()
    {
        x = (x + 1) % 256;
        y = (y + S[x]) % 256;

        S.Swap(x, y);

        return S[(S[x] + S[y]) % 256];
    }
}

static class SwapExt
{
    public static void Swap<T>(this T[] array, int index1, int index2)
    {
        T temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
}
*/