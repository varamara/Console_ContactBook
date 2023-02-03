using Console_ContactBook.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ContactBook.Tests_x
{
    public class FileService_Tests
    {
        FileService fileService;
        public string content;

        public FileService_Tests()
        {
            fileService = new FileService();
            fileService.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
            content = JsonConvert.SerializeObject(new { FirstName = "Test", LastName = "Contact" });
        }

        [Fact]
        public void Should_Create_a_File_With_Json_Content()
        {
            fileService.Save(content);
            string result = fileService.Read(content);

            Assert.True(File.Exists(fileService.FilePath));
            Assert.Equal(result.Trim(), content);
        }
    }
}

