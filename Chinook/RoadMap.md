✅ Updated Razor Pages Coursework Roadmap
🔹 PHASE 1 – Display & Navigation
✅ Display albums in a table

Columns: Album | Artist | Genre | Details | Update | Delete

Fetch Genre from related table (via Track → Genre)

Display the first genre associated with the album's tracks

✅ Details page structure

Show:

Album title

Artist name

Genre

Track list (ordered by track number or name)

Back button

🔹 PHASE 2 – Add New Album Flow
🔨 Create page for new albums

Form inputs:

Album Title

Artist (with <datalist>)

Genre (dropdown from genre table)

Dynamic Track List

Each track input should inherit selected Genre

Add/Remove Track buttons

“Populate Dummy Album” button (with JS)

🔨 Insert new album into DB

Save album, related tracks, and assign selected genre to tracks

🔹 PHASE 3 – Update & Delete
🔨 Edit Album

Allow user to update title, artist, genre, tracks

🔨 Delete Album

Confirmation or inline delete from table

🔹 PHASE 4 – UX Features
✨ Alphabetical sorting

Sort albums A–Z by title

✨ Search functionality

Filter by album title, artist, or genre

🧠 Extra Step: Add Genre Model + Relationships
To support this, we’ll need to:

✅ Add a Genre.cs model

✅ Modify Track.cs to include navigation property to Genre

✅ Update ChinookContext.cs to include Genres

✅ What’s Next?
Let’s do this in steps:

Step 1: Add Genre model + update Track + ChinookContext
Step 2: Modify Index page to display Genre
Step 3: Add Genre dropdown to Create.cshtml