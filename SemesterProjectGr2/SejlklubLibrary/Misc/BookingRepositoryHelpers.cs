public static class BookingRepositoryHelpers
{
    /// <summary>
    /// Gets all bookings for a specific boat from a list of bookings.
    /// </summary>
    /// <param name="bookingList">The list of bookings to get bookings from.</param>
    /// <param name="boat">The boat to get bookings for.</param>
    /// <returns>List of bookings that use the boat from the given list.</returns>
    public static List<Booking> GetBookingsByBoat(List<Booking> bookingList, Boat boat)
    {
        List<Booking> matchingBookings = new List<Booking>();
        foreach (Booking booking in bookingList)
        {
            if (booking.Boat.Id == boat.Id)
            {
                matchingBookings.Add(booking);
            }
        }
        return matchingBookings;
    }

    /// <summary>
    /// Gets all bookings for a specific member from a list of bookings.
    /// </summary>
    /// <param name="bookingList">The list of bookings to get bookings from.</param>
    /// <param name="member">The member to get bookings for.</param>
    /// <returns>List of bookings made by the member from the given list.</returns>
    public static List<Booking> GetBookingsByMember(List<Booking> bookingList, Member member)
    {
        List<Booking> matchingBookings = new List<Booking>();
        foreach (Booking booking in bookingList)
        {
            if (booking.Member.Id == member.Id)
            {
                matchingBookings.Add(booking);
            }
        }
        return matchingBookings;
    }

    /// <summary>
    /// Gets all active bookings from a list of bookings.
    /// </summary>
    /// <param name="bookingList">The list of bookings to get bookings from.</param>
    /// <returns>List of bookings that are active from the given list.</returns>
    public static List<Booking> GetActiveBookings(List<Booking> bookingList)
    {
        List<Booking> activeBookings = new List<Booking>();
        foreach (Booking booking in bookingList)
        {
            if (booking.IsActive)
            {
                activeBookings.Add(booking);
            }
        }
        return activeBookings;
    }

    /// <summary>
    /// Gets all booking in the specified time interval.
    /// </summary>
    /// <param name="bookingList">List of bookings to get bookings from.</param>
    /// <param name="start">Start time of interval.</param>
    /// <param name="end">End time of interval.</param>
    /// <returns></returns>
    public static List<Booking> GetBookingsInTimeInterval(List<Booking> bookingList, DateTime start, DateTime end)
    {
        List<Booking> bookings = new List<Booking>();
        foreach (Booking booking in bookingList)
        {
            if (booking.StartTime <= end && booking.EndTime >= start)
                bookings.Add(booking);
        }
        return bookings;
    }

    /// <summary>
    /// Validates that the specified booking does not conflict with existing bookings for the same boat within the given
    /// time interval.
    /// </summary>
    /// <param name="bookingsList">The list of existing bookings to check for potential conflicts.</param>
    /// <param name="memberToCheck">The member making the booking.</param>
    /// <param name="boatToCheck">The boat being booked.</param>
    /// <param name="startTime">The start time of the booking.</param>
    /// <param name="endTime">The end time of the booking.</param>
    public static string ValidateBooking(List<Booking> bookingsList, Member? memberToCheck, Boat? boatToCheck, DateTime startTime, DateTime endTime, Booking? bookingToUpdate = null)
    {
        string bookingStatus = "";
        if (memberToCheck == null)
            bookingStatus += "Member not selected.\n";

        if (boatToCheck == null)
            bookingStatus += "Boat not selected.\n";

        if (startTime == DateTime.MinValue)
            bookingStatus += "Start time not set.\n";

        if (endTime == DateTime.MinValue)
            bookingStatus += "End time not set.\n";

        if (startTime >= endTime)
            bookingStatus += "End time must be after start time.\n";


        List<Booking> bookings = new List<Booking>();

        bookings = GetBookingsInTimeInterval(bookingsList, startTime, endTime);
        bookings = GetBookingsByBoat(bookings, boatToCheck);
        if (bookings.Count == 0)
            return bookingStatus;
        else if (bookingToUpdate != null)
        {
            int count = 0;
            foreach (Booking b in bookings)
            {
                if (b.Id != bookingToUpdate.Id)
                    count++;
            }

            if (count == 0)
                return bookingStatus;
        }
        else
        {
            bookingStatus += $"Boat with Id {boatToCheck.Id} has conflicting bookings:\n";
        }
        foreach (Booking b in bookings)
        {
            bookingStatus += $"already booked from {b.StartTime.ToString("yyyy/MM/dd HH:mm:ss")} to {b.EndTime.ToString("yyyy/MM/dd HH:mm:ss")}.\n";
        }

        return bookingStatus;
    }

    /// <summary>
    /// Prints a list of bookings to the console with key information.
    /// </summary>
    /// <param name="bookings">List of bookings to print</param>
    public static void PrintBookings(List<Booking> bookings)
    {
        foreach (Booking booking in bookings)
        {
            Console.WriteLine($"Booking {booking.Id}" +
                $"\n\t{booking.StartTime.ToString("yyyy/MM/dd HH:mm:ss")} to {booking.EndTime.ToString("yyyy/MM/dd HH:mm:ss")}" +
                $"\n\tMember: {booking.Member.Id} {booking.Member.Name} " +
                $"\n\tBoat: {booking.Boat.Id} {booking.Boat.Nickname}");
            Console.WriteLine("--------------------------------------------------------");
        }
    }

    /// <summary>
    /// Basic statistics for a boat from a list of bookings.
    /// </summary>
    /// <param name="bookings">List of bookings to check from</param>
    /// <param name="boat">The boat to gather statistics about</param>
    /// <returns>Returns a string containing information about the total number of bookings and total time booked</returns>
    public static string BookingStatisticForBoatString(List<Booking> bookings, Boat boat)
    {
        int totalBookings = 0;
        TimeSpan totalDuration = TimeSpan.Zero;
        foreach (Booking booking in bookings)
        {
            if (booking.Boat.Id == boat.Id)
            {
                totalBookings++;
                totalDuration += (booking.EndTime - booking.StartTime);
            }
        }
        return $"Boat {boat.Id} {boat.Nickname} " +
            $"\n\tTotal Bookings : {totalBookings}" +
            $"\n\tTotal booking duration {totalDuration.TotalHours} hours";
    }

    /// <summary>
    /// Gets the total time a boat has been booked for from a list of bookings.
    /// </summary>
    /// <param name="bookings">List of bookings to check from</param>
    /// <param name="boat">The boat to check</param>
    /// <returns>TimeSpan corresponding to the total time the boat has been booked</returns>
    public static TimeSpan TotalTimeBookedForBoat(List<Booking> bookings, Boat boat)
    {
        TimeSpan totalDuration = TimeSpan.Zero;
        foreach (Booking booking in bookings)
        {
            if (booking.Boat.Id == boat.Id)
            {
                totalDuration += (booking.EndTime - booking.StartTime);
            }
        }
        return totalDuration;
    }

    /// <summary>
    /// Gets the boat with the most bookings from a list of bookings.
    /// </summary>
    /// <param name="bookings">List of bookings to check from</param>
    /// <returns>The boat with the most bookings or null if no bookings exist</returns>
    public static Boat? GetMostBookedBoat(List<Booking> bookings)
    {
        if (bookings.Count == 0)
            return null;

        Boat mostBookedBoat = bookings[0].Boat;
        int maxBookings = 0;
        Dictionary<string, int> boatBookingCounts = new Dictionary<string, int>();
        foreach (Booking booking in bookings)
        {
            string boatId = booking.Boat.Id;
            if (boatBookingCounts.ContainsKey(boatId))
            {
                boatBookingCounts[boatId]++;
            }
            else
            {
                boatBookingCounts[boatId] = 1;
                
            }

            if (boatBookingCounts[boatId] > maxBookings)
            {
                maxBookings = boatBookingCounts[boatId];
                mostBookedBoat = booking.Boat;
            }
        }
        return mostBookedBoat;
    }

    /// <summary>
    /// Gets the boat with the longest total booking time from a list of bookings.
    /// </summary>
    /// <param name="bookings">List of bookings to check from</param>
    /// <returns>The boat with the longest total booking time or null if no bookings exist</returns>
    public static Boat? GetBoatWithLongestBookingTime(List<Booking> bookings)
    {
        if (bookings.Count == 0)
            return null;

        Boat longestBookedBoat = bookings[0].Boat;
        TimeSpan maxDuration = TimeSpan.Zero;
        Dictionary<string, TimeSpan> boatBookingDurations = new Dictionary<string, TimeSpan>();
        foreach (Booking booking in bookings)
        {
            string boatId = booking.Boat.Id;
            TimeSpan bookingDuration = booking.EndTime - booking.StartTime;
            if (boatBookingDurations.ContainsKey(boatId))
            {
                boatBookingDurations[boatId] += bookingDuration;
            }
            else
            {
                boatBookingDurations[boatId] = bookingDuration;
            }

            if (boatBookingDurations[boatId] > maxDuration)
            {
                maxDuration = boatBookingDurations[boatId];
                longestBookedBoat = booking.Boat;
            }
        }
        return longestBookedBoat;
    }

    /// <summary>
    /// Basic statistics for a member from a list of bookings.
    /// </summary>
    /// <param name="bookings">List of bookings to check from</param>
    /// <param name="member">The member to check</param>
    /// <returns>A string with information about the total number of bookings and total time booked</returns>
    public static string MemberStatisticsString(List<Booking> bookings, Member member)
    {
        int totalBookings = 0;
        TimeSpan totalDuration = TimeSpan.Zero;
        foreach (Booking booking in bookings)
        {
            if (booking.Member.Id == member.Id)
            {
                totalBookings++;
                totalDuration += (booking.EndTime - booking.StartTime);
            }
        }
        return $"Member {member.Id} {member.Name} " +
            $"\n\tTotal Bookings : {totalBookings}" +
            $"\n\tTotal booking duration {totalDuration.TotalHours} hours";
    }

    /// <summary>
    /// Gets the total time a member has booked from a list of bookings.
    /// </summary>
    /// <param name="bookings">List of bookings to check</param>
    /// <param name="member">The member to check</param>
    /// <returns>A TimeSpan corresponding to the total time the member has booked a boat</returns>
    public static TimeSpan TotalTimeBookedForMember(List<Booking> bookings, Member member)
    {
        TimeSpan totalDuration = TimeSpan.Zero;
        foreach (Booking booking in bookings)
        {
            if (booking.Member.Id == member.Id)
            {
                totalDuration += (booking.EndTime - booking.StartTime);
            }
        }
        return totalDuration;
    }

    /// <summary>
    /// Gets the member with the most bookings from a list of bookings.
    /// </summary>
    /// <param name="bookings">List of bookings to check from</param>
    /// <returns>The member with most bookings or null if no bookings exist</returns>
    public static Member? GetMemberWithMostBookings(List<Booking> bookings)
    {
        if (bookings.Count == 0)
            return null;

        Member mostActiveMember = bookings[0].Member;
        int maxBookings = 0;
        Dictionary<string, int> memberBookingCounts = new Dictionary<string, int>();
        foreach (Booking booking in bookings)
        {
            string memberId = booking.Member.Id;
            if (memberBookingCounts.ContainsKey(memberId))
            {
                memberBookingCounts[memberId]++;
            }
            else
            {
                memberBookingCounts[memberId] = 1;
            }
            if (memberBookingCounts[memberId] > maxBookings)
            {
                maxBookings = memberBookingCounts[memberId];
                mostActiveMember = booking.Member;
            }
        }
        return mostActiveMember;
    }

    /// <summary>
    /// Gets the member with the longest total booking time from a list of bookings.
    /// </summary>
    /// <param name="bookings">List of bookings to check from</param>
    /// <returns>The member with the longest total booking time or null if no bookings exist</returns>
    public static Member? GetMemberWithLongestBookingTime(List<Booking> bookings)
    {
        if (bookings.Count == 0)
            return null;

        Member longestBookingMember = bookings[0].Member;
        TimeSpan maxDuration = TimeSpan.Zero;
        Dictionary<string, TimeSpan> memberBookingDurations = new Dictionary<string, TimeSpan>();
        foreach (Booking booking in bookings)
        {
            string memberId = booking.Member.Id;
            TimeSpan bookingDuration = booking.EndTime - booking.StartTime;
            if (memberBookingDurations.ContainsKey(memberId))
            {
                memberBookingDurations[memberId] += bookingDuration;
            }
            else
            {
                memberBookingDurations[memberId] = bookingDuration;
            }
            if (memberBookingDurations[memberId] > maxDuration)
            {
                maxDuration = memberBookingDurations[memberId];
                longestBookingMember = booking.Member;
            }
        }
        return longestBookingMember;
    }


}