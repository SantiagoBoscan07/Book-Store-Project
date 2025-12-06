using System.Text.RegularExpressions;

namespace BookStoreBO
{
    public static class Validator
    {
        // Method to validate title input
        public static (bool, string) ValidateTitleInput(string titleID, string title, string priceText)
        {
            // Trim inputs
            titleID = titleID?.Trim() ?? string.Empty;
            title = title?.Trim() ?? string.Empty;
            priceText = priceText?.Trim() ?? string.Empty;

            // Title ID required
            if (string.IsNullOrWhiteSpace(titleID))
                return (false, "Title ID is required.");

            // Title required
            if (string.IsNullOrWhiteSpace(title))
                return (false, "Title is required.");

            // Validate price
            if (!string.IsNullOrEmpty(priceText))
            {
                if (!decimal.TryParse(priceText, out decimal price))
                    return (false, "Price must be a valid number (e.g. 12.99).");

                if (price < 0m)
                    return (false, "Price cannot be negative.");
            }

            return (true, string.Empty);
        }

        // Method to validate publisher input
        public static (bool, string) ValidatePublisherInput(string publisherID)
        {
            // Trim input
            publisherID = publisherID?.Trim() ?? string.Empty;

            // Publisher ID required
            if (string.IsNullOrWhiteSpace(publisherID))
                return (false, "Publisher ID is required.");

            // Fixed valid IDs
            string[] validFixedIds = { "1756", "1622", "0877", "0736", "1389" };

            // Check against fixed IDs and pattern
            bool matchesFixed = validFixedIds.Contains(publisherID);
            bool matchesPattern = Regex.IsMatch(publisherID, @"^99\d\d$");

            // Validate publisher ID
            if (!matchesFixed && !matchesPattern)
            {
                return (false,
                    "Publisher ID must be one of the following: 1756, 1622, 0877, 0736, 1389, or follow the numeric pattern 99##.");
            }

            // If all validations pass
            return (true, string.Empty);
        }

        // Method to validate author input
        public static (bool, string) ValidateAuthorInput(string authorID, string firstName, string lastName,string phone, bool contractedSelected, string zip)
        {
            // Author ID 
            if (string.IsNullOrWhiteSpace(authorID))
                return (false, "Author ID is required.");

            // First name
            if (string.IsNullOrWhiteSpace(firstName))
                return (false, "First name is required.");

            // Last name
            if (string.IsNullOrWhiteSpace(lastName))
                return (false, "Last name is required.");

            // Phone — must be entered
            if (string.IsNullOrWhiteSpace(phone))
                return (false, "Phone number is required.");

            // Contracted radio buttons
            if (!contractedSelected)
                return (false, "Please select Contracted or Not Contracted.");

            // Zip code, if entered, must be 5 digits
            if (!string.IsNullOrWhiteSpace(zip) && !Regex.IsMatch(zip, @"^\d{5}$"))
            {
                return (false, "ZIP code must be exactly 5 digits.");
            }

            // If all validations pass
            return (true, string.Empty);
        }
    }
}
