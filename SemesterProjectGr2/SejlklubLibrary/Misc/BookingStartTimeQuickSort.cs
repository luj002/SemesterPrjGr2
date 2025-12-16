public static class BookingStartTimeQuickSort
{
    /// <summary>
    /// Sorts the list of bookings in place using the QuickSort algorithm.
    /// </summary>
    /// <param name="bookings">List of bookings to sort</param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    private static void QuickSort(List<Booking> bookings, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(bookings, low, high);
            QuickSort(bookings, low, pivotIndex - 1);
            QuickSort(bookings, pivotIndex + 1, high);
        }
    }
    /// <summary>
    /// Finds the correct index of the pivot element and partitions the array around the pivot.
    /// </summary>
    /// <remarks>
    /// All elements with index lower than pivot will be less than or equal to pivot.
    /// All elements with index higher than pivot will be greater than pivot.
    /// So the pivot-element is in its correct sorted position.
    /// </remarks>
    /// <param name="bookings"> The list of bookings to partition</param>
    /// <param name="low"> The loweset index of the sublist to partition</param>
    /// <param name="high"> The highest index of the sublist to partition</param>
    /// <returns>
    /// Returns the correct index of the pivot element.
    /// </returns>
    private static int Partition(List<Booking> bookings, int low, int high)
    {
        int mid = (low + high) / 2;
        DateTime pivot = bookings[mid].StartTime;

        while (low <= high)
        {
            // Increases low index while the element at low is less than the pivot
            while (bookings[low].StartTime < pivot)
            {
                low++;
            }
            // Decreases high index while the element at high is greater than the pivot
            while (bookings[high].StartTime > pivot)
            {
                high--;
            }
            // If element at low is less than or equal to the element high, swap the elements at low and high
            if (low <= high)
            {
                Swap(bookings, low, high);
                low++;
                high--;
            }
        }
        // At this point, the low index is the correct index of the pivot element
        return low;
    }

    /// <summary>
    /// Swaps two elements in the list.
    /// </summary>
    /// <param name="bookings">List to swap elements in</param>
    /// <param name="i">First element to swap</param>
    /// <param name="j">Second element to swap</param>
    private static void Swap(List<Booking> bookings, int i, int j)
    {
        Booking temp = bookings[i];
        bookings[i] = bookings[j];
        bookings[j] = temp;
    }
}
