import React, { useState } from 'react';
import axios from 'axios';

const CreatePost = () => {
  const [title, setTitle] = useState('');
  const [excerpt, setExcerpt] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    axios.post('/api/posts', { title, excerpt })
      .then(response => {
        console.log('Post created:', response.data);
        setTitle('');
        setExcerpt('');
      })
      .catch(error => console.error('Error creating post:', error));
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Create a New Post</h2>
      <div>
        <label>Title:</label>
        <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} required />
      </div>
      <div>
        <label>Excerpt:</label>
        <textarea value={excerpt} onChange={(e) => setExcerpt(e.target.value)} required />
      </div>
      <button type="submit">Create Post</button>
    </form>
  );
};

export default CreatePost;
