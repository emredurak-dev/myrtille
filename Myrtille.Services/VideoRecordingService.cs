using System.Diagnostics;
using System.IO;

public class VideoRecordingService
{
    private Process ffmpegProcess;

    public void StartRecording(string outputPath)
    {
       

        var startInfo = new ProcessStartInfo
        {
            FileName = @"C:\ffmpeg\bin\ffmpeg.exe",
            Arguments = $"-f gdigrab -framerate 25 -i desktop -c:v libx264 -preset veryfast -crf 23 -pix_fmt yuv420p \"{outputPath}\"",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardError = true,
            RedirectStandardOutput = true
        };
        ffmpegProcess = Process.Start(startInfo);
    }



    public void StopRecording()
    {
        if (ffmpegProcess != null && !ffmpegProcess.HasExited)
        {
            ffmpegProcess.Kill();
            ffmpegProcess.WaitForExit();
        }
    }
}