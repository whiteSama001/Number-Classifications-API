
# Number Classification API

This is a Number Classification API that takes a number as input and returns interesting mathematical properties about it, along with a fun fact. It is designed to provide the classification of numbers like Armstrong, odd, and even properties.

## Technologies Used
- **C#** for the backend API development
- **Numbers API** for fetching fun facts about numbers

## API Specification

- **Endpoint**: `GET /api/classify-number?number=<number>`
  - **Request Parameter**: `number` (integer)
  - **Response Format**: JSON

### Response Example (200 OK):
```json
{
  "number": 371,
  "is_prime": false,
  "is_perfect": false,
  "properties": ["armstrong", "odd"],
  "digit_sum": 11,
  "fun_fact": "371 is an Armstrong number because 3^3 + 7^3 + 1^3 = 371"
}
```

### Response Example (400 Bad Request):
```json
{
  "number": "alphabet",
  "error": true
}
```

### Parameters
- `number`: The number to be classified. It must be an integer. Non-integer values or invalid inputs will return an error response.

### Functionality:
1. The API accepts GET requests with a number parameter.
2. It classifies the number and provides:
   - Whether it is a prime number.
   - Whether it is a perfect number.
   - A list of properties (`"armstrong"`, `"odd"`, `"even"`, etc.)
   - The sum of its digits.
   - A fun fact fetched from the Numbers API.
3. Returns appropriate HTTP status codes:
   - `200 OK` for valid responses.
   - `400 Bad Request` for invalid inputs.

### Properties:
- **Armstrong number**: A number that is equal to the sum of the cubes of its digits (e.g., 371).
- **Prime number**: A number that is greater than 1 and has no divisors other than 1 and itself.
- **Perfect number**: A number that is equal to the sum of its divisors excluding itself.

### Possible values for `properties`:
- `["armstrong", "odd"]` – If the number is both an Armstrong number and odd.
- `["armstrong", "even"]` – If the number is an Armstrong number and even.
- `["odd"]` – If the number is not an Armstrong number but is odd.
- `["even"]` – If the number is not an Armstrong number but is even.

## Installation Instructions

1. Clone the repository:
   ```bash
   git clone <repository_url>
   cd <project_directory>
   ```

2. Install dependencies (if any). For this C# project, you might use .NET Core:
   ```bash
   dotnet restore
   ```

3. Run the API locally:
   ```bash
   dotnet run
   ```

4. The API will be running at `http://localhost:5000`.

## Usage

- To use the API, send a `GET` request to `/api/classify-number?number=<number>`.
  
Example request:
```bash
curl "http://<your-domain.com>/api/classify-number?number=371"
```

## Deployment

The API has been deployed and is publicly accessible via [this link](<your-deployment-url>).

## Testing

- Test the API by sending GET requests with different numbers using tools like [Postman](https://www.postman.com) or [Curl](https://curl.se).

### Example Tests:
- `GET /api/classify-number?number=371` should return the classification for 371.
- `GET /api/classify-number?number=5` should return the classification for 5.

## Version Control

The project is hosted on GitHub:
- Repository: [<your-github-repository-link>](<repository_url>)

## Notes

- This API uses the Numbers API to fetch fun facts about numbers.
- The code includes error handling for invalid input, ensuring that non-integer values return a `400 Bad Request` response.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
