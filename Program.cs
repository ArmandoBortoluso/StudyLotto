string filePath = @"./studyFolder/study.csv";

Console.Write("Welcome to Study Lotto.\n");

Console.WriteLine("Let's see what to study this week!");

if(!File.Exists(filePath)){
    Console.WriteLine("File not found. Make sure that the study.csv file exists in the directory studyFolder");

} else {

    List<String> fileLines = new List<string>();
    Boolean isHeader = true;
    string line;

    using (FileStream fStream = File.OpenRead(filePath)) {

        StreamReader? sR = new StreamReader(fStream);

        while(!sR.EndOfStream){

            line = sR.ReadLine();

            //Ignore file header
            if(isHeader){
                isHeader = false;
                continue;
            }
            
            fileLines.Add(line);
        }

        sR.Close();
    }

    Random randNum = new Random();
    
    int luckyNum = randNum.Next(0, fileLines.Count);

    string luckySub = fileLines[luckyNum];

    Console.WriteLine("This week's subject is " + luckySub);

}


