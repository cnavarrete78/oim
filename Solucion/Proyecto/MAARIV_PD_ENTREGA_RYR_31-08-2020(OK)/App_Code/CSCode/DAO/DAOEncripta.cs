using System;
using System.IO;
using System.Security.Cryptography; 
using System.Text; 


/// <summary>
/// DAO Encargado de realizar la encripción de los passwords 
/// </summary>
public class DAOEncripta
{
	public DAOEncripta()
	{
    }
	
    /// <summary>
    /// Método encargado de encriptar una cadena de bytes 
    /// </summary>
    /// <param name="byteCadena">Cadena a ser criptografiada</param>
    /// <param name="password">Password que utiliza el método de encripción (Rijndael) para proceder</param>
    /// <param name="VectorInicializacion">Vector de inicialización para el método de encripción</param>
    /// <returns>Retorna la una cadena de bytes encriptada</returns>
    public byte[] encriptacion(byte[] byteCadena, byte[] password, byte[] VectorInicializacion) 
    { 
        // Se crea el MemoryStream donde se cargara la cadena encriptada 
        MemoryStream ms = new MemoryStream(); 

        // usamos un algoritmo simétrico poara realizar la encripcion en este caso el Rijndael
        Rijndael algoritmo = Rijndael.Create(); 
        
        // Se inicializan los valores para el password y para el vector de inicialización 
        algoritmo.Key = password;
        algoritmo.IV = VectorInicializacion; 

        // creamos un CryptoStream para recibir la información de la cadena al momento de ser criptografiada
        CryptoStream cs = new CryptoStream(ms, algoritmo.CreateEncryptor(), CryptoStreamMode.Write);              
        cs.Write(byteCadena, 0, byteCadena.Length);              
        cs.Close();                 
        byte[] cadenaEncriptada = ms.ToArray();

        return cadenaEncriptada; 
    }

    /// <summary>
    /// Método encargado de recibir la información correspondiente al password del usuario como un String y 
    /// de devolver la cadena como un String tambien 
    /// </summary>
    /// <param name="cadenaLimpia">Cadena a encriptar</param>
    /// <param name="passwordEncrypt">string Password del método de encripción</param>
    /// <returns></returns>

    public string encriptacion(string cadenaLimpia, string passwordEncrypt) 
    { 
        // convertimos la cadena a bytes
        byte[] cadenaBytes = System.Text.Encoding.Unicode.GetBytes(cadenaLimpia); 

        // se obtiene un derivado del password a bytes, utilizando una cadena de bytes, esto con el fin de hacer más segura la encripción. 
        PasswordDeriveBytes pdb = new PasswordDeriveBytes(passwordEncrypt, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

        // se utiliza el metodo "Encriptacion" para obtener la cadena de bytes encriptada 
        // el vector de inicialización se genera a partir del derivado en bytes del password
        byte[] cadenaEncriptada = encriptacion(cadenaBytes, pdb.GetBytes(32), pdb.GetBytes(16)); 

        // se convierte en String la cadena de bytes y se retorna. 
        return Convert.ToBase64String(cadenaEncriptada); 
    }

  
      #region Encriptar 

            // Método para encriptar un texto plano usando el algoritmo (Rijndael). 
            // Este es el mas simple posible, muchos de los datos necesarios los definimos como constantes.
            // <param name="textoQueEncriptaremos">texto a encriptar</param> 
            // <returns>Texto encriptado</returns> 

            public string Encriptar(string textoQueEncriptaremos, string passwordEncrypt) 
            {
                return Encriptar(textoQueEncriptaremos, passwordEncrypt, "s@lAvz", "MD5", 1, "@1B2c3D4e5F6g7H8", 128);       
            }  

            // Método para encriptar un texto plano usando el algoritmo (Rijndael) 
            // <returns>Texto encriptado</returns> 
            public static string Encriptar(string textoQueEncriptaremos, string passBase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize) 
            { 
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector); 
                byte[] saltValueBytes  = Encoding.ASCII.GetBytes(saltValue); 
                byte[] plainTextBytes  = Encoding.UTF8.GetBytes(textoQueEncriptaremos); 

                PasswordDeriveBytes password = new PasswordDeriveBytes(passBase, saltValueBytes, hashAlgorithm, passwordIterations);
                byte[] keyBytes = password.GetBytes(keySize / 8); 
        
                RijndaelManaged symmetricKey = new RijndaelManaged() 
                { 
                    Mode = CipherMode.CBC 
                }; 

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes); 
                MemoryStream memoryStream = new MemoryStream(); 
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length); 
                cryptoStream.FlushFinalBlock();  
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close(); 
                cryptoStream.Close(); 
                string cipherText = Convert.ToBase64String(cipherTextBytes);  
                return cipherText; 
            } 

      #endregion  

      #region Desencriptar 
     
            // Método para desencriptar un texto encriptado. 
            // <returns>Texto desencriptado</returns> 
            public string Desencriptar(string textoEncriptado, string passwordEncrypt) 
            {
                return Desencriptar(textoEncriptado, passwordEncrypt, "s@lAvz", "MD5", 1, "@1B2c3D4e5F6g7H8", 128);
            } 

            // Método para desencriptar un texto encriptado (Rijndael)            
            // <returns>Texto desencriptado</returns> 
            public static string Desencriptar(string textoEncriptado, string passBase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize) 
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector); 
                byte[] saltValueBytes  = Encoding.ASCII.GetBytes(saltValue); 
                byte[] cipherTextBytes = Convert.FromBase64String(textoEncriptado); 
                PasswordDeriveBytes password = new PasswordDeriveBytes(passBase, saltValueBytes, hashAlgorithm, passwordIterations); 
                byte[] keyBytes = password.GetBytes(keySize / 8); 
                RijndaelManaged symmetricKey = new RijndaelManaged() 
                { 
                    Mode = CipherMode.CBC 
                }; 

                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes); 
                MemoryStream  memoryStream = new MemoryStream(cipherTextBytes); 
                CryptoStream  cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length]; 
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length); 
                memoryStream.Close(); 
                cryptoStream.Close(); 
                string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount); 

                return plainText; 
            } 

      #endregion 

  } 
