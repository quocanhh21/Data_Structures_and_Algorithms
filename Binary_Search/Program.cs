using System.Diagnostics;

#region Binary Search
//Key features of Binary Search:

//Efficiency: Binary search has a time complexity of O(log n), making it significantly faster than linear search for large datasets.
//Requires sorted data: The input data must be sorted in ascending or descending order for binary search to work correctly.
//Divides and conquers: Binary search follows a divide-and-conquer approach, repeatedly dividing the search space in half until the target element is found or the search space becomes empty.   
//Comparison-based: Binary search compares the target element with the middle element of the search space to determine which half to continue searching.
//Iterative or recursive: Binary search can be implemented iteratively or recursively.
//Handles duplicates: Binary search can handle duplicate elements in the sorted data.
//Can be adapted for other data structures: Binary search can be adapted to search for elements in other data structures, such as sorted arrays or balanced trees.
#endregion Binary Search
public class Program
{
    public static void Main()
    {
        // test
        int[] nums = { 2, 7, 11, 15, 17, 19, 22, 25, 26, 28 };
        int target = 25;
        int result = BinarySearch(nums, target);
        Debug.Assert(result == -1);
    }

    public static int BinarySearch(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                return mid;
            }

            // If x greater, ignore left half
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            // If x is smaller, ignore right half
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}
