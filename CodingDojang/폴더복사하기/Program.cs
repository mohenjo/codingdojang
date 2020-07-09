using System;
using System.IO;

namespace CD202
{
    class Program
    {
        static void Main(string[] args)
        {
            CopyFolder cp = new CopyFolder(@"D:\Temp\test");
            cp.MakeACopy();

            Console.ReadKey();
        }
    }

    class CopyFolder
    {
        // 원래 폴더 경로
        private readonly DirectoryInfo OriginalPath;

        // 부모 폴더 경로
        private readonly DirectoryInfo ParentPath;

        // 사용 가능한 다음 사본 폴더 경로
        private DirectoryInfo NextTargetPath
        {
            get
            {
                int label = 0;
                string nextTargetPathNameTry = "사본";
                while (Directory.Exists($"{ParentPath}\\{nextTargetPathNameTry}"))
                {
                    label++;
                    nextTargetPathNameTry = $"사본_{label}";
                }
                return new DirectoryInfo($"{ParentPath}\\{nextTargetPathNameTry}");
            }
        }

        public CopyFolder(string originalPath)
        {
            OriginalPath = new DirectoryInfo(originalPath);
            ParentPath = Directory.GetParent(originalPath);
        }

        // 다음 사본 폴더에 원래 폴더 내용 복사
        public void MakeACopy()
        {
            DirectoryInfo TargetPath = NextTargetPath; // 복사 대상 경로명에 대해

            // 원래 경로명 문자열을 대상 경로명 문자열로 치환함에 의해 폴더 및 파일 복사함

            // 사본 (하위)폴더 생성
            Directory.CreateDirectory(TargetPath.FullName);
            foreach (string dirPath in Directory.GetDirectories(OriginalPath.FullName, "*", 
                SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(OriginalPath.FullName, TargetPath.FullName));
            }

            // 사본 폴더에 파일 복사
            foreach (string filePath in Directory.GetFiles(OriginalPath.FullName, "*.*", 
                SearchOption.AllDirectories))
            {
                File.Copy(filePath, filePath.Replace(OriginalPath.FullName, TargetPath.FullName), true);
            }
        }
    }
}
