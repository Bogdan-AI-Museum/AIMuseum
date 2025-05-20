# 🎓 AI-Based Interactive Exhibition Guide

## 📌 Overview

This project is part of a diploma thesis and focuses on building an **AI-powered interactive guide** for virtual exhibitions. The system integrates real-time exhibit recognition, multilingual communication, and generative AI to deliver personalized, dynamic, and engaging experiences for users.

Visitors can freely explore a 3D virtual space, point their camera at exhibits, and ask questions using voice or text. Responses are generated in real time by a virtual AI guide and delivered either in text or spoken form.

---

## 🚀 Features

* 🎯 **Real-time exhibit recognition**
* 🗣️ **Natural language interaction** (voice and text)
* 🧠 **AI-generated answers** using GPT technology
* 🔊 **Voice responses** via text-to-speech
* 🎮 **Free 3D navigation** (WASD + mouse)
* 🧩 **Modular, extensible architecture**

---

## 🛠️ Technologies Used

### Core Technologies

* [**Unity**](https://unity.com/) – 3D environment and interface
* **C#** – Core programming language

### AI & Input/Output Integration

* 🎤 **Speech-to-Text (Input)**: [Whisper.Unity](https://github.com/Macoron/whisper.unity)
  → Provides voice recognition with detailed documentation, usage examples, and parameters.

* 🧠 **AI Processing**: [Google Gemini Unity Package](https://github.com/UnityGameStudio/Gemini-Unity-Package)
  → Handles communication with generative AI (e.g., for answering user questions).

* 🔈 **Text-to-Speech (Output)**: [UnityRustTTS](https://github.com/keijiro/UnityRustTts)
  → Converts text responses into speech; includes setup instructions and examples.

### Additional Tools & Libraries

* 📦 **[Zenject](https://github.com/modesttree/Zenject)** – Dependency Injection framework for scalable architecture.
* 🧩 **[SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)** – Enables runtime polymorphic selection in the Unity Inspector.
* ⚡ **[UniTask](https://github.com/Cysharp/UniTask)** – Lightweight async/await support optimized for Unity.
* 🧰 **[NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes)** – Extends Unity Inspector with useful attributes for development.

---
