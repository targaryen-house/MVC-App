## Software Requirements

### Vision
To allow users to easily view, rate, and comment on trails and trail conditions across the US, and to add in trails to our database that are not currently documented.

The product, while similar to others, solves the issue of unknown/undocumented trails that locals/enthusiasts may know and want to share.

This product is community sourced and community serving. It helps spread information and locations to enthusiasts and beginners alike.

### Scope
	
###### In – 
- Show trails to users from a database of trails across the US
- Provide trail conditions 
- Provide location weather
- Provide an interface to leave comments on each trail
- Provide topographical maps and trail head locations
###### Out – 
- We will not provide search and rescue. We will not be held liable or accountable for personal injury or death due to our system not providing timely or correct information. All information provide to our website is by users and may or may not be correct. This is not a failsafe, nor a replacement for proper documentation of trips provided to user POCs nor park ranger stations.
- We will not provide your information to ranger stations for initial trip documentation.
- We are not a camping reservation system.

### MVP

MVP will be a website that allows users to search for hiking trails and leave comments, trail conditions, and input new trails if any they know are not included in our or third-party databases. There is an index view that allows a user to search, this queries our API and then a third-party API for known trail information in a specific range. If the trail information is not currently in our API database, we query the third party and send the info to our API. 

Once queried the APIs send the information to our search results view. In the results view, the user can select one of the shown trails, or the user can add limiters to the search from the list of options on the left side of the screen. 

If a trail the user knows is not listed in either our or the third-party database, there is an option on this view that allows one to input all their known information about their tail and submit it to the database. There will be a minimum amount of information required for this option. 

Once the user selects a trail, the app will move to the next view. In the details view, the user can see images, trail difficulty ratings, weather (sourced from a third API), elevation, topographical maps, a trail writeup, user input trail conditions and user comments. The user can also input their own comments, trail conditions and trail rating on this page. 

Our MVP will have a database server side that holds trail comments and user information. We will be using our inhouse API to store user input trail information and user ratings of existing trails. We will be using multiple third-party APIs to query trail information, weather, and topographical maps. 

### Stretch
Our stretch goals include, but are not limited to:
- An emergency notification system that sends trip information and dates to appropriate authorities if the user does not check in within a certain time after the designated end of their trip.
- Additional sport information such as climbing, mountain biking, kayaking, and location information for those sports.
- Allowing users to show route information in user input trails, instead of just trailheads. 

### Functional Requirements
- A user can create a username.
- A user can search for trails.
- A user with a username can add a trail to our API database via the Switchback web app.
- A user can select a specific trail to see weather, maps, trail information, comments, and ratings.
- A user with a username can input comments, ratings, and trail conditions.

### Non-Functional Requirements 
- Usability – Our web app will be easy to use and understand. 
- Open Source – Anyone can use our API and its code, design documents, and content. 

### Data Flow

When the user hits the site, the user is shown a view with a search form. In the search form the user can input a variety of information from a zip code to a park, and the web app will query our API for trail information. If our API does not have the information the web app will query a third-party API for the information, then send the information to our API to cache. Once cached the information is sent to our model to format the information and then the results view. 

If the user knows of a trail not in our or the third-party APIs databases, the user has an option on the results view to go to a new view that allows the user to input all they know about the trail and send it to our API after the information has been formatted. 

If the user finds a trail on the results page that they want more information about, they can select it and the web app will then query other APIs for topographical maps and weather information after which the user will be taken to the details view. The details view shows the trail details, maps and weather information. It also allows users to input comments, trail ratings and trail conditions. The web app will send the information input on this page to the database if it is a user comment or to the API if it is a trail condition or trail rating. 
