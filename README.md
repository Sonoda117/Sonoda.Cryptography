# Sonoda.Cryptography

Extensiones para llevar a cabo hashing y criptografía simétrica sobre cadenas de texto. Los algoritmos disponibles para ambas tareas son aquellos con una implementación disponible en `System.Security.Cryptography`, concretamente clases que hereden de `HashAlgorithm` para métodos de hashing, y de `SymmetricAlgorithm` para métodos de encriptación.

## Especificaciones del Proyecto
- Tipo: Class Library
- Framework: NetCore 3.1
- Lenguaje: C# 8

--- 
## Uso de Extensiones

- **Hash**<br>
    Los métodos `.Hash<T>()` y `.Hash<T>(Encoding)` retornan un arreglo de bytes procesado por una instancia del algoritmo utilizado como parámetro, siendo ésta la representación más primitiva del hash. Los bytes de la cadena original son obtenidos con el parámetro Encoding, si se utiliza la sobrecarga sin parámetros, se utilizará `UTF-8` como medio para procesar la cadena original.

    El proyecto cuenta con dos extensiones para la representación de bytes en cadenas de texto, dichos métodos son `.ToHex()` para Hexadecimal y `.ToBase64()` para aquel con el mismo nombre. La idea de solo regresar los bytes procesados y no su representación en texto busca que el usuario pueda representar su hash usando cualquier otro sistema, o de cualquier otra manera.
```C#
string Hex = "SampleText".Hash<SHA256>().ToHex(); // E737305F4D8317D8F4E6A765126E40DACF7E50F2FC4052F8AE74BA2B8A452804
```

- **EncryptSymmetric / DecryptSymmetric**<br>
    El método `.EncryptSymmetric<T>(byte[], byte[], Encoding)` sirve, como su nombre indica, para encriptar una cadena de texto mediante un algoritmo simétrico. Para ello, utiliza un Encoding y dos ByteArrays, que representan un Key y un Vector de Inicialización (IV), parámetros requeridos para cualquier implementación de un algoritmo simétrico. Al igual que Hash, también devuelve un arreglo de bytes que puede ser representado en string con una extensión habida en el proyecto.

    `.DecryptSymmetric<T>(byte[], byte[])`, por el contrario, retorna los bytes originales del texto encriptado, es por ello que la extensión `.ToString(Encoding)` toma ese parámetro, tiene el objetivo de representar dichos bytes originales a texto plano. Dicho esto, sobre señalar que el Encoding utilizado para encriptar una cadena debe ser el mismo que se utilice cuando busque desencriptarse.
```C#
// Parámetros
var ChoosenEncoding = Encoding.UTF8;
var Key = ChoosenEncoding.GetBytes("67534EF3D5F343DF907182B935420EF9");
var IV = ChoosenEncoding.GetBytes("B2AFE2B8F9AB4F00B44CFA2F13B0569F");

// Encriptado
string Base64 = "SampleText".EncryptSymmetric<Aes>(Key, IV, ChoosenEncoding).ToBase64(); // 7TZt9mcQuoi17XoFQIa+Og==

// Desencriptado
string Base = Base64.DecryptSymmetric<Aes>(Key, IV).ToString(ChoosenEncoding); // SampleText
```

Un punto a resaltar es que, cuando se desencripta una cadena, ésta debe encontrarse en formato hexadecimal o base64, el método lo detectará automáticamente, pero arrojará una excepción si el texto se encuentra en algún otro formato, es por ello que para su encriptación y posterior representación, debe utilizar una de las extensiones consideradas, `.ToHex()` o `.ToBase64()`.

--- 
## Algoritmos Probados

**Hashing**
- MD5
- SHA-1
- SHA-256
- SHA-384
- SHA-512

**Criptografía Simétrica**
- AES
- DES
- RC2
- Rijndael
- TripleDES