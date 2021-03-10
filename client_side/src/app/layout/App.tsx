import { useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import LoadingComponents from './LoadingComponents';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';

const App = () => {
  const { activityStore } = useStore();
  const { loadingInitial } = activityStore;


  useEffect(() => {
    activityStore.loadActivities();
  }, [activityStore]);

  if (loadingInitial) return <LoadingComponents content='Loading app.' />

  return (
    <>
      <NavBar />
      <Container style={{ marginTop: '7rem' }}>
        <ActivityDashboard />
      </Container>
    </>
  );
}

export default observer(App);