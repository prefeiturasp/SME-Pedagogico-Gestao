import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import Dashboard from '../components/navigation/Dashboard';

const AuthenticatedDashboardRoute = ({ component: C, user, ...rest }) => {
    return (
        <Route {...rest}
            render={props => user.isAuthenticated
                ? (
                    <Dashboard>
                        <C />
                    </Dashboard>
                )
                : <Redirect to={`/Login?redirect=${props.location.pathname}${props.location.search}`} />
            }
        />
    );
};

export default connect(
    state => ({ user: state.user }),
)(AuthenticatedDashboardRoute);