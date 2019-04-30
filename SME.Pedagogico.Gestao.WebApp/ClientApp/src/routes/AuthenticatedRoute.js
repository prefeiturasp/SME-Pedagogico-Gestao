import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';

const AuthenticatedRoute = ({ component: C, user, ...rest }) => {
    return (
        <Route {...rest}
            render={props => user.isAuthenticated
                ? <C />
                : <Redirect to={`/Login?redirect=${props.location.pathname}${props.location.search}`} />
            }
        />
    );
};

export default connect(
    state => ({ user: state.user }),
)(AuthenticatedRoute);
