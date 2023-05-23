# UserCrudInterview
<h1> Endpoints </h1>
<h2> Get </h2>
<h3> /Users </h3>

 <p> Gets all Users information<p>
 <p> /Users</p>
 <br>
 <p> Get all user with the same email </p>
 <p> /Users?email="Insert Email" </p>
  <br>
 <p> Get all user with the same phone number </p>
 <p> /Users?phone="Insert Phone Number" </p>
  <br>
 <p> Get all user with both email and phone number </p>
 <p> /Users?email="Insert Email"&phone="Insert Phone Number" </p>
  <br>
 <p> Get all user and order by attribute </p>
 <p> /Users?orderby="Insert Attribute" </p>
  <br>
 <br>
<h2> Post </h2>
<h3> /users/add </h3>
 <p> Add a user into the database </p>
 <p> Information of the user is added into the body </p>
 <p> /Users/add </p>
 <br>
 <br>
<h2> Delete </h2>
 <h3> /users/:id </h3>
  <p> Deletes a user from the database by Id </p>
  <p> /Users/id?="Insert User ID Here" </p>
   <br>
    <br>
 <h2> Put </h2>
 <h3> /users/:id </h3>
  <p> Update the User by the ID </p>
  <p> Information of the user that needs to be updated is placed in the Body</p>
  <p> /Users/id?="Insert User ID Here" </p>
