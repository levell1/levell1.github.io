---
title: "프로젝트 1 "
layout: archive
permalink: categories/project
author_profile: true
sidebar_main: true
---

***
<!-- 공백포함 -> site.categories.['a b c'] -->

{% assign posts = site.categories.Project %}
{% for post in posts %} {% include archive-single2.html type=page.entries_layout %} {% endfor %}



