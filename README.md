# Sonoda.Cryptography

Extensiones para llevar a cabo hashing y criptografía simétrica sobre cadenas de texto. Los algoritmos disponibles para ambas tareas son aquellos con una implementación disponible en `System.Security.Cryptography`, concretamente clases que hereden de `HashAlgorithm` para métodos de hashing, y de `SymmetricAlgorithm` para métodos de encriptación.

---
## Especificaciones del Proyecto
- Tipo: Class Library
- Framework: NetCore 3.1
- Lenguaje: C# 8

--- 
## Uso de Extensiones

- **Hash con representación Hexadecimal**<br>
```C#
var Hex = "SampleText".Hash<SHA256>().ToHex(); // E737305F4D8317D8F4E6A765...
```

- **Encriptado con representación en Base64 y Desencriptado**<br>
```C#
// Parámetros
var ChoosenEncoding = Encoding.UTF8;
var Key = ChoosenEncoding.GetBytes("67534EF3D5F343DF907182B935420EF9");
var IV = ChoosenEncoding.GetBytes("B2AFE2B8F9AB4F00B44CFA2F13B0569F");

// Encriptado
var Base64 = "SampleText".EncryptSymmetric<Aes>(Key, IV, ChoosenEncoding).ToBase64(); // 7TZt9mcQu...

// Desencriptado
var Base = Base64.DecryptSymmetric<Aes>(Key, IV).ToString(ChoosenEncoding); // SampleText
```

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