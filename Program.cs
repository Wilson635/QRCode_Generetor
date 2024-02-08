// See https://aka.ms/new-console-template for more information

// using System;

// class QrcodeGenerator 
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello, World!");
//         Console.WriteLine("Hello, Generons un Code QR à partir d'une chaine");
//         Console.WriteLine("Allez, Let's Go !!!!");

//         string result = Console.ReadLine();
//         Console.WriteLine("https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=(result)");
//         Console.
//     }
// }

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

namespace App
{
    class QrCodeGenerator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, Generons un Code QR à partir d'une chaine");
            Console.WriteLine("Allez, Let's Go !!!!");
            Console.WriteLine("Enter the data to encode in the QR code:");
            string data = Console.ReadLine();

            // Generate the QR code
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);


            // Specify the folder path to save the QR code image-
            string folderPath = @"E:\app\Csharp_App\QrCodeGenerator\images";

            // Create the folder if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Save the QR code as a PNG image file inside the specified folder
            string fileName = Path.Combine(folderPath, data + "_" + "QRCode.png");
            qrCodeImage.Save(fileName, ImageFormat.Png);

            // Display the QR code image using an image viewer application
            DisplayQRCodeImage(fileName);

            Console.ReadLine();
        }

        static void DisplayQRCodeImage(string imagePath)
        {
            try
            {
                // Check if the file exists
                if (System.IO.File.Exists(imagePath))
                {
                    // Use the default image viewer to open and display the QR code image
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = imagePath,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                else
                {
                    Console.WriteLine("QR code image not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

