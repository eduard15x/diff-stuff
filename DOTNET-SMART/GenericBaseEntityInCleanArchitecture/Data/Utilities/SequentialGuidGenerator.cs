namespace GenericBaseEntityInCleanArchitecture.Data.Utils
{
    public static class SequentialGuidGenerator
    {
        public static Guid NewSequentialGuid()
        {
            byte[] randomBytes = Guid.NewGuid().ToByteArray();
            byte[] timestampBytes = BitConverter.GetBytes(DateTime.UtcNow.Ticks);

            // Ensure timestamp bytes are in the right order
            if (BitConverter.IsLittleEndian)
                Array.Reverse(timestampBytes);

            // Combine timestamp with random GUID bytes
            byte[] guidBytes = new byte[16];
            Array.Copy(timestampBytes, 0, guidBytes, 0, 8);
            Array.Copy(randomBytes, 8, guidBytes, 8, 8);

            return new Guid(guidBytes);
        }
    }
}