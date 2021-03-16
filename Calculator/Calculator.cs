using System;

namespace Calculator
{
	public enum OperationType : byte
	{
		Sum = 1,
		Multiplication = 2,
		Max = 3,
		Min = 4
	}

	public class Calculator
    {

        public static byte Calculate(OperationType type, byte[] args)
        {
            byte result = 0;

            switch (type)
            {
                case OperationType.Sum: //O(N)
                    for (int i = 0; i < args.Length; i++)
                        result += args[i];
                    break;
                case OperationType.Multiplication: //O(N)
					result = args[0];
                    for (int i = 1; i < args.Length; i++)
                        result *= args[i];
                    break;
                case OperationType.Max: //O(N)
                    result = args[0];
                    for (int i = 1; i < args.Length; i++)
                        if (args[i] > result)
                            result = args[i];
                    break;
                case OperationType.Min: //O(N)
                    result = args[0];
                    for (int i = 1; i < args.Length; i++)
                        if (args[i] < result)
                            result = args[i];
                    break;
                default:
                    break;
            }

            return result;
        }

        public static byte Median(byte[] args)
        {
			if (MinOfNth(args, GetOddMedianIndex(args), out byte result))
				return result;

			return 0;
        }




		private static int GetOddMedianIndex(byte[] args)
        {
			return args.Length / 2 + 1;
        }

		private static bool MinOfNth(byte[] nums, int nth, out byte result) //O(N)
		{
			var index = 0;
			for (var i = 1; i < nums.Length; i++)
			{
				if (nums[i] < nums[index])
				{
					byte temp;
					if (i > index + 1)
					{
						temp = nums[index];
						nums[index] = nums[index + 1];
						nums[index + 1] = temp;
					}

					temp = nums[index];
					nums[index] = nums[i];
					nums[i] = temp;

					index++;
				}
			}

			if (nth < index + 1)
			{
				var size = index;
				if (size == 0)
				{
					result = 0;
					return false;
				}

				var copy = new byte[index];
				Array.Copy(nums, 0, copy, 0, index);
				return MinOfNth(copy, nth, out result);
			}
			else if (nth > index + 1)
			{
				var size = nums.Length - (index + 1);
				if (size == 0)
				{
					result = 0;
					return false;
				}

				var copy = new byte[size];
				Array.Copy(nums, index + 1, copy, 0, size);
				return MinOfNth(copy, nth - (index + 1), out result);
			}

			result = nums[index];
			return true;
		}
	}
}
