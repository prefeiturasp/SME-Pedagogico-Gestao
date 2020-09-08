import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import createSagaMiddleware from 'redux-saga';
import * as User from './User';
import UserSaga from '../sagas/User';
import FrequencySaga from '../sagas/Frequency';
import ClassRoomStudentsSaga from '../sagas/ClassRoomStudents';
import PollSaga from '../sagas/Poll';
import PollReportSaga from '../sagas/PollReport';
import FilterSaga from '../sagas/Filters';
import SondagemAutoralSaga from '../sagas/SondagemAutoral'
import * as LeftMenu from './LeftMenu';
import * as Calendar from './Calendar';
import * as Frequency from './Frequency';
import * as ClassRoomStudents from './ClassRoomStudents';
import * as Poll from './Poll';
import * as PollReport from './PollReport';
import * as Filters from './Filters';
import * as PollRouter from './PollRouter';
import * as PollOptionSelectLock from './PollOptionSelectLock';
import * as Data from './Data';
import * as SondagemAutoral from './SondagemAutoral';
import * as SondagemPortugues from './SondagemPortuguesStore';
import { persistStore, persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage'; // defaults to localStorage for web and AsyncStorage for react-native
import logger from 'redux-logger';

export default function configureStore(history, initialState) {
    const reducers = {
      //Inserir reducers necessários
      //Ex.:
      //counter: Counter.reducer,
      user: User.reducer,
      leftMenu: LeftMenu.reducer,
      calendar: Calendar.reducer,
      frequency: Frequency.reducer,
      classRoomStudents: ClassRoomStudents.reducer,
      poll: Poll.reducer,
      pollReport: PollReport.reducer,
      filters: Filters.reducer,
      pollRouter: PollRouter.reducer,
      pollOptionSelectLock: PollOptionSelectLock.reducer,
      data: Data.reducer,
      autoral: SondagemAutoral.reducer,
      sondagemPortugues: SondagemPortugues.reducer,
    };

    const reduxSaga = createSagaMiddleware();

    const persistConfig = {
        key: 'root',
        storage,
        whitelist: ["user"]
    };

    const middleware = [
        //Inserir middlewares necessários
        //Ex.:
        //thunk,
        reduxSaga,
    ];

    // In development, use the browser's Redux dev tools extension if installed
    const enhancers = [];
    const isDevelopment = process.env.NODE_ENV === 'development';
    if (isDevelopment && typeof window !== 'undefined' && window.__REDUX_DEVTOOLS_EXTENSION__) {
        enhancers.push(window.__REDUX_DEVTOOLS_EXTENSION__());
    }

    // Redux-logger on development
    if (isDevelopment)
        middleware.push(logger);

    const appReducer = combineReducers({
        ...reducers
    });

    const rootReducer = (state, action) => {
        if (action.type === User.types.LOGOUT_USER) {
            storage.removeItem('persist:root');
            state = undefined;
        }

        return appReducer(state, action)
    };

    const persistedReducer = persistReducer(persistConfig, rootReducer);

    const store = createStore(
        persistedReducer,
        initialState,
        compose(applyMiddleware(...middleware), ...enhancers)
    );

    const persistor = persistStore(store);

    reduxSaga.run(UserSaga);
    reduxSaga.run(FrequencySaga);
    reduxSaga.run(ClassRoomStudentsSaga);
    reduxSaga.run(PollSaga);
    reduxSaga.run(PollReportSaga);
    reduxSaga.run(FilterSaga);
    reduxSaga.run(SondagemAutoralSaga);

    return ({ store, persistor });
}