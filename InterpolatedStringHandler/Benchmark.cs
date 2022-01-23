namespace InterpolatedStringHandler
{
    using System.Text;
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Benchmark]
        public string BuildDateWithStringConcatenationMethod() => string.Concat(1982, "/", 11, "/", 22);

        [Benchmark]
        public string BuildDateWithStringConcatenationMethodToString() =>
            string.Concat(1982.ToString(), "/", 11.ToString(), "/", 22.ToString());

        [Benchmark]
        public string BuildDateWithStringConcatenation() =>
            1982 + "/" + 11 + "/" + 22;

        [Benchmark]
        public string BuildDateWithStringBuilder()
        {
            var builder = new StringBuilder();
            builder.Append(1982);
            builder.Append('/');
            builder.Append(11);
            builder.Append('/');
            builder.Append(22);

            return builder.ToString();
        }

        [Benchmark]
        public string BuildDateWithOldStringInterpolation() => string.Format("{0}/{1}/{2}", 1982, 11, 22);

        [Benchmark]
        public string BuildDateWithNewStringInterpolation() => $"{1982}/{11}/{22}";
}


}