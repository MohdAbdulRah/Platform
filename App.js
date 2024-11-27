import React from 'react';
import BlogPosts from './components/BlogPosts';
import CreatePost from './components/CreatePost';
import './App.css';

function App() {
  return (
    <div className="App">
      <header>
        <nav>
          <h1>Blog Platform</h1>
        </nav>
      </header>
      <main>
        <CreatePost />
        <BlogPosts />
      </main>
    </div>
  );
}

export default App;
