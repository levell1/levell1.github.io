---
title: "디자인패턴"
layout: archive
permalink: categories/designpattern
author_profile: true
sidebar_main: true
---

***
<!-- 공백포함 -> site.categories.['a b c'] -->

{% assign posts = site.categories.['Design Pattern']%}
{% for post in posts %} {% include archive-single2.html type=page.entries_layout %} {% endfor %}

