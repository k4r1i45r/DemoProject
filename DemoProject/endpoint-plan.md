# API Endpoint Plan - RaceDay System

| HTTP Method | Route | Description | Role Required | Request Body | Expected Response |
|-------------|-------|-------------|---------------|--------------|-------------------|
| POST | `/api/auth/register` | Register a new participant account. | None | `{ "firstName", "lastName", "email", "password", "dateOfBirth", "gender", "phone" }` | `201 Created` – user profile. `400 Bad Request` – validation fails. |
| POST | `/api/auth/login` | Authenticate user and return JWT token. | None | `{ "email", "password" }` | `200 OK` – `{ token, user }`. `401 Unauthorized` – invalid credentials. |
| GET | `/api/profile` | Get logged-in user's profile. | Any | None | `200 OK` – full profile. `404 Not Found` – user missing. |
| PUT | `/api/profile` | Update logged-in user's profile. | Any | `{ "firstName", "lastName", "phone", "address" }` | `200 OK` – updated profile. `400 Bad Request` – invalid data. |
| GET | `/api/events` | Get list of all upcoming events. | Any | None | `200 OK` – array of events. |
| GET | `/api/events/{id}` | Get details of a single event. | Any | None | `200 OK` – event + categories. `404 Not Found`. |
| POST | `/api/events` | Create a new event. | Organiser | `{ "eventName", "eventDate", "location", "description", "categoryId", "maxParticipants" }` | `201 Created` – new event. `400 Bad Request`. |
| PUT | `/api/events/{id}` | Update an existing event. | Organiser | `{ "eventName", "eventDate", "location" }` | `200 OK` – updated event. `403 Forbidden`, `404 Not Found`. |
| DELETE | `/api/events/{id}` | Delete an event. | Organiser | None | `204 No Content`. `404 Not Found`. |
| GET | `/api/categories` | Get all event categories. | Any | None | `200 OK` – array of categories. |
| POST | `/api/categories` | Create a new category. | Organiser | `{ "categoryName", "categoryType", "description" }` | `201 Created` – new category. |
| POST | `/api/events/{eventId}/enrol` | Enrol logged-in participant in an event category. | Participant | `{ "categoryId" }` | `201 Created` – enrolment. `409 Conflict` – already enrolled. |
| GET | `/api/enrolments/me` | Get all enrolments for logged-in participant. | Participant | None | `200 OK` – array of enrolments. |
| GET | `/api/events/{eventId}/enrolments` | Get all enrolments for a specific event (organiser view). | Organiser | None | `200 OK` – array of enrolments with participants. |
| POST | `/api/results` | Capture a participant's result for an event. | Organiser | `{ "enrolmentId", "finishTime", "chipTime", "overallPosition", "categoryPosition", "pace" }` | `201 Created` – result. `404 Not Found`. |
| GET | `/api/results/me` | Get logged-in participant's personal results history. | Participant | None | `200 OK` – array of results. |