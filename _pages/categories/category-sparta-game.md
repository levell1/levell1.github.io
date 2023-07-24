---
title: "스파르타 강의 게임"
layout: archive
permalink: categories/sparta-game
author_profile: true
sidebar_main: true
---

***
<!-- 공백포함 -> site.categories.['a b c'] -->

{% assign posts = site.categories['Sparta Game']%}
{% for post in posts %} {% include archive-single2.html type=page.entries_layout %} {% endfor %}



