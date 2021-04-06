import React from "react";
import { Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";

function querystring(name, url = window.location.href) {
  name = name.replace(/[[]]/g, "\\$&");

  const regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)", "i");
  const results = regex.exec(url);

  if (results === null) return null;
  if (results[2] === null) return "";

  return decodeURIComponent(results[2].replace(/\+/g, " "));
}

const UnauthenticatedRoute = ({ component: C, user, ...rest }) => {
  const redirect = querystring("redirect");
  return (
    <Route
      {...rest}
      render={(props) =>
        user.isAuthenticated === false ? (
          <C />
        ) : (
          <Redirect
            to={redirect === "" || redirect === null ? "/" : redirect}
          />
        )
      }
    />
  );
};

export default connect((state) => ({ user: state.user }))(UnauthenticatedRoute);
