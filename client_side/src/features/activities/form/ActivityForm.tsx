import { observer } from 'mobx-react-lite';
import { useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router';
import { Button, Header, Segment } from 'semantic-ui-react';
import LoadingComponents from '../../../app/layout/LoadingComponents';
import { useStore } from '../../../app/stores/store';
import { v4 as uuid } from 'uuid';
import { Link } from 'react-router-dom';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import MyTextInput from '../../../app/common/form/MyTextInput';
import MyTextArea from '../../../app/common/form/MyTextArea';
import MySelectInput from '../../../app/common/form/MySelectInput';
import { categoryOptions } from '../../../app/common/options/categoryOptions';
import MyDateInput from '../../../app/common/form/MyDateInput';
import { Activity } from '../../../app/models/activity';

const ActivityForm = () => {
  const history = useHistory();
  const { activityStore } = useStore();
  const { createActivity, updateActivity, loading, loadActivity, loadingInitial } = activityStore;
  const { id } = useParams<{ id: string }>();

  const [activity, setActivity] = useState<Activity>({
    id: '',
    title: '',
    category: '',
    description: '',
    date: null,
    city: '',
    venue: ''
  });

  const validationSchema = Yup.object({
    title: Yup.string().required('Title is required'),
    description: Yup.string().required('Description is required'),
    category: Yup.string().required('Category is required'),
    date: Yup.string().required('Date is required').nullable(),
    city: Yup.string().required('city is required'),
    venue: Yup.string().required('Venue is required'),
  });

  useEffect(() => {
    if (id) loadActivity(id).then(activity => setActivity(activity!));
  }, [id, loadActivity]);

  const handleFormSubmit = (activity: Activity) => {
    if (activity.id.length === 0) {
      let newActivity = {
        ...activity,
        id: uuid()
      };

      createActivity(newActivity).then(() => history.push(`/activities/${newActivity.id}`));
    } else {
      updateActivity(activity).then(() => history.push(`/activities/${activity.id}`));
    }
  };

  if (loadingInitial) return <LoadingComponents content='Loading activity...' />

  return (
    <Segment clearing>
      <Header content='Activity Details' sub color='teal' />
      <Formik
        validationSchema={validationSchema}
        enableReinitialize
        initialValues={activity}
        onSubmit={values => handleFormSubmit(values)}>
        {({ handleSubmit, isValid, isSubmitting, dirty }) => (
          <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
            <MyTextInput name='title' placeholder='Title' />
            <MyTextArea rows={3} name='description' placeholder='Description' />
            <MySelectInput options={categoryOptions} name='category' placeholder='Category' />
            <MyDateInput
              name='date'
              placeholderText='Date'
              showTimeSelect
              timeCaption='time'
              dateFormat='MMMM d, yyyy h:mm aa' />
            <Header content='Location Details' sub color='teal' />
            <MyTextInput name='city' placeholder='City' />
            <MyTextInput name='venue' placeholder='Venue' />
            <Button
              type='submit'
              positive
              floated='right'
              loading={loading}
              disabled={isSubmitting || !dirty || !isValid}
              content='Submit' />
            <Button as={Link} to='/activities' floated='right' type='submit' content='Cancel' />
          </Form>
        )}
      </Formik>
    </Segment>
  )
}

export default observer(ActivityForm);